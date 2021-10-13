using System;
using System.Collections.Generic;
using System.Linq;

namespace BAI
{
    public class BAI_Afteken1
    {
        /// ------------------------------------------------------------
        /// <summary>
        /// Filtert een lijst. Hierbij worden alle elementen die maar
        /// 1x voorkomen verwijderd
        /// </summary>
        /// <param name="lijst">De lijst die wordt doorlopen
        /// (wordt in functie veranderd)</param>
        /// ------------------------------------------------------------
        public static void Opdr1FilterList(List<int> lijst)
        {
            // Maak een dictionary aan
            Dictionary<int, int> dic = new Dictionary<int, int>();

            // Loop door de lijst heen
            for (int i = 0; i < lijst.Count; i++)
            {
                // Als item van de lijst al bestaat in de dictionary doe dan plus een
                if (dic.ContainsKey(lijst[i]))
                {
                    dic[lijst[i]] += 1;
                }
                // bestaat hij nog niet in de lijst voeg hem dan toe aan de lijst
                else
                {
                    dic.Add(lijst[i], 1);
                }
            }

            // Loop door de lijst heen. We gebruiken hier de l.count, omdat er items van de lijst verwijderd worden
            // en als we lijst.count gebruiken we dan elke keer een count minder krijgen, omdat deze wordt verwijderd van de lijst
            for (int i = 0; i < lijst.Count; i++)
            {
                // Als item meer dan 1x voorkomt dan pas verwijderen
                if (dic[lijst[i]] < 2)
                {
                    lijst.RemoveAt(i);

                    i -= 1;
                }
            }
        }

        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een queue van de getallen 1 t/m 50 (in die volgorde
        /// toegevoegd)
        /// </summary>
        /// <returns>Een queue met hierin 1, 2, 3, .., 50</returns>
        /// ------------------------------------------------------------
        public static Queue<int> Opdr2aQueue50()
        {
            Queue<int> q = new Queue<int>();

            for (int i = 1; i <= 50; i++)
            {
                q.Enqueue(i);
            }

            return q;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Haalt alle elementen uit een queue. Voegt elk element dat
        /// deelbaar is door 4 toe aan een stack
        /// </summary>
        /// <param name="queue">De queue die uitgelezen wordt</param>
        /// <returns>De stack met hierin de elementen die deelbaar zijn
        /// door 4</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr2bStackFromQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();

            while(queue.Count > 0)
            {
                if (queue.Peek() % 4 == 0)
                {
                    stack.Push(queue.Dequeue());
                } else
                {
                    queue.Dequeue();
                }
            }

            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een stack met hierin unieke random getallen</summary>
        /// <param name="lower">De ondergrens voor elk getal (inclusief)</param>
        /// <param name="upper">De bovengrens voor elk getal (inclusief)</param>
        /// <param name="count">Het aantal getallen</param>
        /// <returns>De stack met unieke random getallen</returns>
        /// ------------------------------------------------------------
        //public static Stack<int> Opdr3RandomNumbers(int lower, int upper, int count)
        //{
        //    // Init alle benodige vars
        //    Stack<int> stack = new Stack<int>();
        //    List<int> list = new List<int>();
        //    Random random = new Random();

        //    // Zet alle mogelijke opties in een dict
        //    for (int i = lower; i <= upper; i++)
        //    {
        //        list.Add(i);
        //    }

        //    // Loop erdoor heen zolang we het aantal nog niet hebben bereikt
        //    while (count > 0)
        //    {
        //        // maak een random nummer aan die in de lijst zit
        //        int randomNumber = random.Next(0, list.Count);
        //        // Push nummer naar de stack
        //        stack.Push(list[randomNumber]);

        //        // Verwijder nummer van lijst
        //        list.Remove(list[randomNumber]);

        //        // Zet de count 1 naar beneden
        //        count -= 1;
        //    }

        //    return stack;
        //}


        public static Stack<int> Opdr3RandomNumbers(int lower, int upper, int count)
        {
            // Init alle benodige vars
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            Random random = new Random();

            // Loop erdoor heen zolang we het aantal nog niet hebben bereikt
            while (count > 0)
            {
                int randomNumber = random.Next(lower, upper + 1);

                if (! dic.ContainsKey(randomNumber))
                {
                    dic.Add(randomNumber, randomNumber);
                    stack.Push(randomNumber);

                    count -= 1;
                }
            }

            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Drukt een IEnumerable (List, Stack, Queue, ..) van getallen
        /// af naar de Console
        /// <param name="enu">De IEnumerable om af te drukken</param>
        /// ------------------------------------------------------------
        static void PrintEnumerable(IEnumerable<int> enu)
        {
            foreach (int i in enu)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            List<int> list;
            Queue<int> queue;
            Stack<int> stack;

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1 : FilterList ===");
            list = new List<int>() { 1, 3, 5, 7, 3, 8, 9, 5 };
            PrintEnumerable(list);
            Opdr1FilterList(list);
            PrintEnumerable(list);

            //Console.WriteLine();
            //Console.WriteLine("=== Opdracht 2 : Stack / Queue ===");
            //queue = Opdr2aQueue50();
            //PrintEnumerable(queue);
            //stack = Opdr2bStackFromQueue(queue);
            //PrintEnumerable(stack);

            //Console.WriteLine();
            //Console.WriteLine("=== Opdracht 3 : Random number ===");
            //stack = Opdr3RandomNumbers(100, 150, 10);
            //PrintEnumerable(stack);
            //stack = Opdr3RandomNumbers(10, 15, 6);
            //stack = Opdr3RandomNumbers(10, 15, 6);
            //PrintEnumerable(stack);
            //stack = Opdr3RandomNumbers(10_000, 50_000, 40_001);
            //PrintEnumerable(stack);
            //Console.WriteLine("DONE");
        }
    }
}
