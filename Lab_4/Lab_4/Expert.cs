using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Expert
    {
        public string Name { get; set; }
        public int[] Preferences { get; set; }

        public Expert(string name, int length)
        {
            Name = name;
            Preferences = new int[length];
        }
    }
}
