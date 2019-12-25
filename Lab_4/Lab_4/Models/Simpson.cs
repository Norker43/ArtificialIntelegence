using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    public class Simpson : Model
    {
        public Simpson() : base() { }

        public override string Execute()
        {
            string[] alt = new string[Experts[0].Preferences.Length];
            int n = Experts[0].Preferences.Length; // количество альтернатив
            int m = Experts.Count; // количество экспертов
            int[,] arr = new int[n, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[j, i] = Experts[i].Preferences[j];
                }
            }
            string win;
            int[,] dop = new int[n, n - 1];
            for (int i = 1; i <= n; i++)
            {
                int alt1 = 0, alt2 = 0, count = 0;
                for (int j = 1; j <= n; j++)
                {
                    if (i != j)
                    {
                        int q = 0, g = 0;
                        for (int k = 0; k < m; k++)
                        {
                            for (int h = 0; h < n; h++)
                            {
                                if (arr[h, k] == i) alt1 = h;
                                if (arr[h, k] == j) alt2 = h;
                            }
                            if (alt1 < alt2) 
                                q++;
                            else 
                                g++;
                        }
                        dop[i - 1, count] = q;
                        count++;
                    }
                }
            }

            int[] min = new int[n]; // выбрать минимальное по строкам, побеждает с максимальным из мах
            int minv = 0, max, p = 1;
            for (int i = 0; i < dop.GetLength(0); i++) 
            {
                minv = dop[i, 0];
                for (int j = 0; j < dop.GetLength(1); j++)
                {
                    if (dop[i, j] < minv && dop[i, j] != 0)
                        minv = dop[i, j];
                }
                min[i] = minv;
            }
            max = min[0];
            for (int i = 1; i < n; i++)
            {
                if (max < min[i])
                {
                    max = min[i];
                    p = i + 1;
                }

            }
            win = "Альтернатива " + p;
            return win;
        }
    }
}
