using System;
using System.Collections.Generic;


namespace BAI
{
    public partial class BAI_Afteken2
    {
        public static bool Vooruit(uint b)
        {
            if ((b & 128) == 128)
            {
               return true;
            }

            //Console.WriteLine($"{Convert.ToString(b, 2).PadLeft(8, '0')}");
            //Console.WriteLine(b);
            // *** IMPLEMENTATION HERE *** //
            return false;
        }
        public static uint Vermogen(uint b)
        {
            // Je moet van boven naar beneden werken omdat je na 1 value kijkt
            // als beiden aanstaan kijkt geeft hij true voor eentje
            if ((b & 96) == 96)
            {
                return 100;
            } else if ((b & 64) == 64)
            {
                return 67;
            } else if ((b & 32) == 32)
            {
                return 33;
            }

            // *** IMPLEMENTATION HERE *** //
            return 0;
        }
        public static bool Wagon(uint b)
        {
            if ((b & 16) == 16)
            {
                return true;
            }
            // *** IMPLEMENTATION HERE *** //
            return false;
        }
        public static bool Licht(uint b)
        {
            if ((b & 8) == 8)
            {
                return true;
            }
            // *** IMPLEMENTATION HERE *** //
            return false;
        }
        public static uint ID(uint b)
        {
            return b & 7;
        }

        public static HashSet<uint> Alle(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();

            for (int i = 0; i < inputStroom.Count; i++)
            {
                set.Add(inputStroom[i]);
            }

            // *** IMPLEMENTATION HERE *** //
            return set;
        }
        public static HashSet<uint> ZonderLicht(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();

            for (int i = 0; i < inputStroom.Count; i++)
            {
                if (! Licht(inputStroom[i]))
                {
                    set.Add(inputStroom[i]);
                }
            }

            return set;
        }
        public static HashSet<uint> MetWagon(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();

            for (int i = 0; i < inputStroom.Count; i++)
            {
                if (Wagon(inputStroom[i]))
                {
                    set.Add(inputStroom[i]);
                }
            }

            return set;
        }
        public static HashSet<uint> SelecteerID(List<uint> inputStroom, uint lower, uint upper)
        {
            HashSet<uint> set = new HashSet<uint>();

            for (int i = 0; i < inputStroom.Count; i++)
            {
                if (ID(inputStroom[i]) >= lower && ID(inputStroom[i]) <= upper)
                {
                    set.Add(inputStroom[i]);
                }
            }

            return set;
        }

        public static HashSet<uint> Opg3a(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();

            set = SelecteerID(inputStroom, 0, 2);
            set.IntersectWith(ZonderLicht(inputStroom));

            return set;
        }

        public static HashSet<uint> Opg3b(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();

            set = Alle(inputStroom);
            set.ExceptWith(Opg3a(inputStroom));
            
            //set = SelecteerID(inputStroom, 2, 8);
            //set.(ZonderLicht(inputStroom));

            return set;
        }

        public static void ToonInfo(uint b)
        {
            Console.WriteLine($"ID {ID(b)}, Licht {Licht(b)}, Wagon {Wagon(b)}, Vermogen {Vermogen(b)}, Vooruit {Vooruit(b)}");
        }

        public static List<uint> GetInputStroom()
        {
            List<uint> inputStream = new List<uint>();
            for (uint i = 0; i < 256; i++)
            {
                inputStream.Add(i);
            }
            return inputStream;
        }

        public static void PrintSet(HashSet<uint> x)
        {
            Console.Write("{");
            foreach (uint i in x)
                Console.Write($" {i}");
            Console.WriteLine($" }} ({x.Count} elementen)");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=== Opgave 1 ===");
            ToonInfo(210);
            Console.WriteLine();

            List<uint> inputStroom = GetInputStroom();

            Console.WriteLine("=== Opgave 2 ===");
            HashSet<uint> alle = Alle(inputStroom);
            PrintSet(alle);
            HashSet<uint> zonderLicht = ZonderLicht(inputStroom);
            PrintSet(zonderLicht);
            HashSet<uint> metWagon = MetWagon(inputStroom);
            PrintSet(metWagon);
            HashSet<uint> groter6 = SelecteerID(inputStroom, 6, 7);
            PrintSet(groter6);
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3a ===");
            HashSet<uint> opg3a = Opg3a(inputStroom);
            PrintSet(opg3a);
            foreach (uint b in opg3a)
            {
                ToonInfo(b);
            }
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3b ===");
            HashSet<uint> opg3b = Opg3b(inputStroom);
            PrintSet(opg3b);
            foreach (uint b in opg3b)
            {
                ToonInfo(b);
            }
            Console.WriteLine();
        }
    }
}
