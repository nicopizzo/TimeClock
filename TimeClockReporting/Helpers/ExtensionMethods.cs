using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock.Reporting.Helpers
{
    public static class ExtensionMethods
    {
        public static KeyValuePair<TKey, TValue> GetEntry<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
        }
    }
}
