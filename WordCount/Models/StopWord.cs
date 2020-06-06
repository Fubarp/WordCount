using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordCount.Models
{
    public class StopWord
    {
        public StopWord()
        {
            Values = new HashSet<string>();
        }

        public HashSet<string> Values { get; set; }

        public StopWord Add(string key)
        {
            Values.Add(key);
            return this;
        }

        public StopWord fileToHashSet()
        {
            FileStream fileStream = new FileStream("stop-words.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
               while(reader.Peek() != -1)
                {
                    Debug.WriteLine("Reading stuff");
                    this.Add(reader.ReadLine());
                }
            }

            fileStream.Close();

            return this;
        }
    }
}
