using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAI
{
    public class TestUtils
    {
        // ------------------------------------------------------------
        // Maakt een lijst van een string. Getallen zijn ints,
        // gescheiden door een spatie
        // ------------------------------------------------------------
        public static List<int> ListFromString(string str)
        {
            List<int> list = new List<int>();

            if (str.Length > 0)
                list = str.Split(" ").Select(Int32.Parse).ToList();
            return list;
        }
    }
}