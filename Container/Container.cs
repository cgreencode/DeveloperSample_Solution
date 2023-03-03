using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException($"The type {implementationType.FullName} must implement the interface {interfaceType.FullName}");
            }

            _map[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            if (_map.TryGetValue(typeof(T), out var implementationType))
            {
                return (T)Activator.CreateInstance(implementationType);
            }

            throw new InvalidOperationException($"No implementation was found for interface {typeof(T).FullName}");
        }
    }
}