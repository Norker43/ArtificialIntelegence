using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Knowledge
{
    static class AttachedProcedure
    {
        public static string GetTime(string value)
        {
            double temp = Convert.ToDouble(value);
            temp /= 10;

            return temp.ToString();
        }

        public static string GetPrice(string value, bool sale)
        {
            double temp = Convert.ToDouble(value);
            temp *= 10;

            if (sale)
            {
                temp *= 0.7;
            }

            return temp.ToString();
        }

        public static string GetSale(string value)
        {
            int countFriends = Convert.ToInt32(value);

            if (countFriends >= 2)
            {
                return "Да";
            }

            return "Нет";
        }

        public static string[] ProcedureParse(string value)
        {
            return new string[] { GetProcedureName(value), GetParametrName(value) };
        }

        private static string GetProcedureName(string value)
        {
            value = value.Substring(0, value.IndexOf('('));

            return value;
        }

        private static string GetParametrName(string value)
        {
            int i = value.IndexOf('(') + 1, j = value.IndexOf(')');
            value = value.Substring(i, j - i);

            return value;
        }
    }
}
