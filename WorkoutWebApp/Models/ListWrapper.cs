using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutWebApp.Models
{
    public class ListWrapper<T>
    {
        Dictionary<string, object> _bag = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                return _bag[key];
            }
            set
            {
                if (_bag.ContainsKey(key))
                {
                    _bag[key] = value;
                }
                else
                {
                    _bag.Add(key, value);
                }
            }
        }

        public IEnumerable<T> Items { get; set; }

        public ListWrapper(IEnumerable<T> items)
        {
            Items = items;
        }
    }
}