﻿using System;
using System.Collections.Generic;
using ShoppingCart.Data.Database;

namespace ShoppingCart.Data.IoC
{
    public class IoC : IIoC
    {
        private static IoC _instance;
        private readonly Dictionary<Type, IAdapter> _adapters;

        public IoC()
        {
            _adapters = new Dictionary<Type, IAdapter>();

            Register<IDatabase>(new NhibernateDatabase());
        }

        public static IoC Instance()
        {
            if (_instance == null)
                _instance = new IoC();

            return _instance;
        }

        public T For<T>()
        {
            return (T)_adapters[typeof(T)];
        }

        private void Register<T>(IAdapter adapter)
        {
            _adapters.Add(typeof(T), adapter);
        }
    }
}
