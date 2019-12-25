using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    public class ClearWinner : Model
    {
        public ClearWinner() : base() { }

        public override string Execute()
        {
            string win;
            string[] alt = new string[Experts[0].Preferences.Length];
            int n = Experts[0].Preferences.Length; // количество альтернатив
            int m = Experts.Count; // количество экспертов
            int plus = 0;
            List<string> par = new List<string>();
            string alter;
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
            for (int i = 1; i < n; i++) // типо берется первая альтернатива
            {
                int alt1 = 0, alt2 = 0;
                for (int j = i + 1; j <= n; j++) // берется следующая относительно первой
                {
                    int q = 0;
                    int g = 0;
                    for (int k = 0; k < m; k++) // отвечает за столбцы
                    {
                        for (int h = 0; h < n; h++) // отвечает за строки
                        {
                            if (arr[h, k] == i)
                                alt1 = h;
                            if (arr[h, k] == j)
                                alt2 = h;
                        }
                        if (alt1 < alt2)
                            q++; // означает, что первая алтернатива больше второй 
                        else
                            g++;
                    }
                    if (q > g)
                    {
                        par.Add("Альтернатива " + (i) + " > Альтернатива: "
                            + (j) + " = " + (q));
                    }
                    else
                    {
                        par.Add("Альтернатива " + (i) + " < Альтернатива "
                            + (j) + " = " + (g));

                        alter = alt[plus];
                        alt[plus] = alt[j - 1];
                        plus++;
                        alt[j - 1] = alter;
                    }
                }
            }
            win = alt[0];

            return win;
        }
    }
}
