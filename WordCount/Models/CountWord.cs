using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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


        public CountWord CreateString(StopWord stopWord)
        {
            String line = "";
            FileStream fileStream = new FileStream("mobydick.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if(line == "")
                    { continue; }
                    string pattern = "[^-_A-Za-z0-9^’]+";

                    string[] substrings = Regex.Split(line, pattern); 
                    foreach (string match in substrings)
                    {
                        String matchWord = match.ToLower();
                        if(match != "" && !stopWord.Values.Contains(matchWord) && match != "’")
                        {
                            if (!this.Values.ContainsKey(matchWord))
                            {
                                this.Add(match.ToLower(), 1);
                            }
                            else
                            {
                                this.Values[match.ToLower()] += 1;
                            }
                        }
                    }
                }
            }

            fileStream.Close();

            return this;
        }
    }

}
