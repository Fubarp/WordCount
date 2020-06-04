using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordCount.Models
{
    public class CountWord
    {
        public CountWord()
        {
            Values = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Values { get; set; }

        public CountWord Add(string key, int value)
        {
            Values.Add(key, value);
            return this;
        }

        
    }

}
