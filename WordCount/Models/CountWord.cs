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
        //[-_A-Za-z0-9^’]+
        public CountWord CreateString(StopWord stopWord)
        {
            //Regex regex = new Regex(@"[-_A-Za-z0-9^’]+");
            String line = "";
            FileStream fileStream = new FileStream("testFile.txt", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if(line == "")
                    { continue; }
                    //Debug.WriteLine("Reading stuff");
                    //this.Add(reader.ReadLine());

                    //Match match = regex.Match(line);
                    //if (match.Success)
                    //{
                    //    // Write original line and the value.
                    //    string[] v = match.Value.Split();
                    //    Debug.WriteLine(line);
                    //    Debug.WriteLine("... " + v[]);
                    //}

                    //string input = "plum-pear";
                    string pattern = "[^-_A-Za-z0-9’]+";

                    string[] substrings = Regex.Split(line, pattern);    // Split on hyphens
                    foreach (string match in substrings)
                    {
                        String matchWord = match.ToLower();
                        if(match != "" && !stopWord.Values.Contains(matchWord))
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

            return this;
        }
    }

}
