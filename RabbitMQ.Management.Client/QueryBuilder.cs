using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace RabbitMQ.Management.Client
{
    internal class QueryBuilder
    {
        public string Build<T>(string endPoint, QueryOrder sorting = QueryOrder.Ascending, Expression<Func<T, object>> sortSelector = null, PropertyFilters<T> propertyFilters = null)
        {
            var dict = new Dictionary<string, string>();

            if (sorting == QueryOrder.Descending)
            {
                dict.Add("sortReverse", "true");
            }

            if (sortSelector != null)
            {
                dict.Add("sort", GetSortingKey(sortSelector));
            }

            if (propertyFilters != null)
            {
                var filters = propertyFilters.GetProperties().ToList();

                if (filters.Any())
                {
                    dict.Add("columns", string.Join(",", filters.Select(GetSortingKey).ToArray()));
                }
            }

            return endPoint + (dict.Any() ? "?" + string.Join("&", dict.Select(x => x.Key + "=" + x.Value).ToArray()) : string.Empty);
        }

        private string GetSortingKey<T>(Expression<Func<T, object>> expression)
        {
            var path = new StringBuilder();
            var memberExpression = GetMemberExpression(expression);

            do
            {
                if (path.Length > 0)
                {
                    path.Insert(0, ".");
                }

                var jsonAttribute = memberExpression.Member.GetCustomAttribute(typeof(JsonPropertyNameAttribute), false);

                path.Insert(0, jsonAttribute != null ? ((JsonPropertyNameAttribute)jsonAttribute).Name : memberExpression.Member.Name);

                memberExpression = GetMemberExpression(memberExpression.Expression);
            }
            while (memberExpression != null);

            return path.ToString();
        }

        private MemberExpression GetMemberExpression(Expression expression)
        {
            if (expression is MemberExpression memberExpression)
            {
                return memberExpression;
            }

            if (!(expression is LambdaExpression lambdaExpression)) return null;

            switch (lambdaExpression.Body)
            {
                case MemberExpression body:
                    return body;
                case UnaryExpression unaryExpression:
                    return ((MemberExpression)unaryExpression.Operand);
                default:
                    return null;
            }
        }
    }
}