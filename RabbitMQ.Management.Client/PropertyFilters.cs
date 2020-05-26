using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RabbitMQ.Management.Client
{
    public class PropertyFilters<T>
    {
        private readonly List<Expression<Func<T, object>>> _propertyFilters;

        private PropertyFilters()
        {
            _propertyFilters = new List<Expression<Func<T, object>>>();
        }

        public static PropertyFilters<T> Build()
        {
            return new PropertyFilters<T>();
        }

        public PropertyFilters<T> AddFilter(Expression<Func<T, object>> filter)
        {
            _propertyFilters.Add(filter);

            return this;
        }

        internal IEnumerable<Expression<Func<T, object>>> GetProperties()
        {
            return _propertyFilters;
        }
    }
}