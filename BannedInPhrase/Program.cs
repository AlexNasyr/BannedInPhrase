using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BannedInPhrase {
    /// <summary>
    /// найти наиболее часто встречающееся слово за исключением "запрещенных" слов
    /// </summary>
    /// <param name="banned">список исключаемых слов</param>
    /// <param name="phrase">фраза для поиска</param>
    class Program {
        static string[] banned = { "in" };
        static string phrase = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        static void Main() {
            foreach(string b in banned) {
                phrase = Regex.Replace(phrase, b, "");
            }

            var splitted = phrase.ToLower().Split(new char[] {' ', ',', '.',  });
            Dictionary<string, int> counts = new();
            foreach(string str in splitted) {
                if(counts.ContainsKey(str)) {
                    counts[str]++;
                }
                else {
                    if(str.Length > 0) {
                        counts.Add(str, 1);
                    }
                }
            }

            var ordered = counts.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"the most common word excluding banned is '{ordered.Last().Key}' it present {ordered.Last().Value} times");
        }
    }
}
