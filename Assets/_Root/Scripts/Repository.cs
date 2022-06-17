﻿using System;
using System.Collections.Generic;

namespace MyGame
{
    internal interface IRepository : IDisposable
    {

    }

    internal abstract class Repository<Tkey, TValue, TConfig> : IRepository
    {
        private readonly Dictionary<Tkey, TValue> items;

        public IReadOnlyDictionary<Tkey, TValue> Items => items;

        public Repository(IEnumerable<TConfig> configs)
        {
            items = CreateRepository(configs);
        }

        private Dictionary<Tkey, TValue> CreateRepository(IEnumerable<TConfig> configs)
        {
            Dictionary<Tkey, TValue> items = new Dictionary<Tkey, TValue>();

            foreach (var config in configs)
            {
                items[GetKey(config)] = CreateItem(config);
            }

            return items;
        }

        protected abstract TValue CreateItem(TConfig config);

        protected abstract Tkey GetKey(TConfig config);


        public void Dispose()
        {
            items.Clear();
        }
    }
}