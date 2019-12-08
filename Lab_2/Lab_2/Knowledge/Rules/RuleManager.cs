using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab_2
{
    static class RuleManager
    {
        public static string[] Sequentialization(string[] consequent)
        {
            string[] parts = consequent[0].Split(':');
            parts = RemoveSpace(parts);

            return parts;
        }

        private static string[] RemoveSpace(string[] parts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i][0] == ' ')
                {
                    parts[i] = parts[i].Remove(0, 1);
                }
            }

            return parts;
        }
    }
}
