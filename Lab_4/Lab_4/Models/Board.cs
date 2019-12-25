using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    class Board : Model
    {
        public Board() : base() { }

        public override string Execute()
        {
            int[] summ = new int[Experts[0].Preferences.Length];

            foreach (Expert expert in Experts)
            {
                for (int i = 1; i <= expert.Preferences.Length; i++)
                {
                    for (int j = 0; j < expert.Preferences.Length; j++)
                    {
                        if (expert.Preferences[j] == i)
                        {
                            summ[i - 1] += expert.Preferences.Length - j;
                        }
                    }
                }
            }

            int value = 0, index = 0;
            for (int i = 0; i < summ.Length; i++)
            {
                if (value < summ[i])
                {
                    index = i;
                    value = summ[i];
                }
            }

            return "Альтернатива " + (index + 1);
        }
    }
}
