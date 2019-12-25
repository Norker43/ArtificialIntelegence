using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    class Kopland : Model
    {
        public Kopland() : base() { }

        public override string Execute()
        {
            string[] alt = new string[Experts[0].Preferences.Length];
            int n = Experts[0].Preferences.Length; // количество альтернатив
            int m = Experts.Count; // количество экспертов
            for (int i = 0; i < n; i++)
            {
                alt[i] = "Альтернатива " + (i + 1);
            }
            int[,] arr = new int[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[j, i] = Experts[i].Preferences[j];
                }
            }
            int[] solv = new int[n];
            for (int i = 1; i <= n; i++)
            {
                int alt1 = 0, alt2 = 0;
                for (int j = 1; j <= n; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            for (int h = 0; h < n; h++)
                            {
                                if (arr[h, k] == i) alt1 = h;
                                if (arr[h, k] == j) alt2 = h;
                            }
                            if (alt1 < alt2) solv[i - 1]++;
                            else solv[i - 1]--;
                        }
                    }
                }
            }
            int tempSolv = solv.Max();
            for (int i = 0; i < solv.Length; i++)
            {
                if (solv[i] == tempSolv)
                    return "Альтернатива " + (i);
            }
            return "";
        }
    }
}
