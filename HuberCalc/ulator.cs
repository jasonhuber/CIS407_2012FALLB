using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuberCalc
{
    public class ulator
    {
        public static int Divide(string x, string y)
        {
            return int.Parse(x) / int.Parse(y);
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public string Add(string x, string y)
        {
            return (int.Parse(x) + int.Parse(y)).ToString();
        }
    }
}
