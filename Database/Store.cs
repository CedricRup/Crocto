using System;
using System.Collections.Generic;
using System.Threading;

namespace Database
{
    public class Store<TElement,TKey>
    {
        private readonly Func<TElement, TKey> keyer;

        public Store(Func<TElement,TKey> keyer)
        {
            this.keyer = keyer;
        }

        readonly Dictionary<TKey,TElement> storage = new Dictionary<TKey, TElement>(); 

        public IEnumerable<TElement> GetAll()
        {
            Thread.Sleep(200);
            return storage.Values;
        }

        public TElement Get(TKey key)
        {
            Thread.Sleep(200);
            return storage[key];
        }

        public void Register(TElement toRegister)
        {
            Thread.Sleep(1000);
            storage[keyer(toRegister)] = toRegister;
        }

        public void Delete(TElement toDelete)
        {
            Thread.Sleep(1000);
            storage.Remove(keyer(toDelete));
        }

        public void Reset()
        {
            storage.Clear();
        }
    }
}
