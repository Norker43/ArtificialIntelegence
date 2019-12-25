using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    class RelativeMajority : Model
    {
        public int Index { get; set; } = 0;

        private double[,] values;

        public RelativeMajority(int alternativesCount) : base()
        {
            values = new double[alternativesCount, 2];
        }

        public override string Execute() { return null; }

        public double[,] Execute(int selectedIndex)
        {
            for (int j = 0; j < values.Length / 2; j++)
            {
                if (j == selectedIndex)
                {
                    values[j, 0]++;
                }
            }

            for (int j = 0; j < values.Length / 2; j++)
            {
                values[j, 1] = values[j, 0] / Experts.Count * 100;
            }

            Index++;
            return values;
        }
    }
}
