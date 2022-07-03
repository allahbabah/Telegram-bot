using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Methods
    {
        public static bool Compare(string a, string[] b)
        {
            foreach (var item in b)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
     
    }
}
