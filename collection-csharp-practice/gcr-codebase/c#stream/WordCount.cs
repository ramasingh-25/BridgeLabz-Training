using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class WordCount
{
    static void Main()
    {
        Dictionary<string, int> map = new Dictionary<string, int>();

        using (StreamReader sr = new StreamReader("text.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                foreach (var w in line.Split(' ', ',', '.', ';'))
                {
                    if (string.IsNullOrWhiteSpace(w)) continue;
                    string k = w.ToLower();
                    map[k] = map.ContainsKey(k) ? map[k] + 1 : 1;
                }
            }
        }

        foreach (var x in map.OrderByDescending(x => x.Value).Take(5))
            Console.WriteLine(x.Key + " : " + x.Value);
    }
}
