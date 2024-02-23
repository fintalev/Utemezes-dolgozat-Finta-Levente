using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0223
{
    internal class Program
    {
        static List<utemezesbeolv> tabor = new List<utemezesbeolv>();
        static List<utemezesbeolv> erdeklodes = new List<utemezesbeolv>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"taborok.txt");
           
            int db=0;
            int max = 0;
            
            while (!sr.EndOfStream)
            {
                tabor.Add(new utemezesbeolv(sr.ReadLine()));
            }
           
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Adatsorok száma: {tabor.Count}");
            Console.WriteLine($"Az először rögzített tábor témája: {tabor.First().tabornev}");
            Console.WriteLine($"Az Az utoljára rögzített tábor témája: {tabor.Last().tabornev}");

            Console.WriteLine("3.feladat:");

            foreach (var item in tabor)
            {
                if (item.tabornev== "zenei")
                {
                    Console.WriteLine($"Zenei tábor kezdődik {item.kezdho}. hó {item.kezdnap}. napján.");
                    db++;
                }
               
                
            }
            if (db == 0)
            {
                Console.WriteLine("Nem volt zenei tábor");
            }

            Console.WriteLine("4.feladat");

            Console.WriteLine("Legnépszerűbbek:");

            foreach(var item in tabor)
            {
                if (item.gyerekek.Count()>max)
                {
                    max = item.gyerekek.Count();
                }
            }

            foreach (var item in tabor) 
            {
                if (item.gyerekek.Count()==max)
                {
                    Console.WriteLine($"{item.kezdho} {item.kezdnap} {item.tabornev}");
                }
            }



            Console.WriteLine("6.feladat");
            Console.Write("hó:");
            int ho=Convert.ToInt32( Console.ReadLine());
            Console.Write("nap:");
            int nap = Convert.ToInt32(Console.ReadLine());
            Sorszam(ho, nap);
            db = 0;

            foreach (var item in tabor)
            {
                int elso = Sorszam(item.kezdho, item.kezdnap);
                int utolso = Sorszam(item.vegho, item.vegnap);
                int megadott = Sorszam(ho,nap);
                if (megadott>=elso&&megadott<=utolso)
                {
                    db++;
                }
            }
            Console.WriteLine($"Ekkor éppen {db} tábor tart. ");

            Console.WriteLine("7.feladat:");
            Console.Write("Adja meg a tanuló betűjelét:");
            string betujel = Console.ReadLine();

            foreach (var item in tabor)
            {
                if (item.gyerekek.Contains(betujel))
                {
                   
                    erdeklodes.Add(item);
                }
            }

            StreamWriter sw = new StreamWriter("egytanulo.txt");
            {
                foreach (var item in erdeklodes.OrderBy(t => Sorszam(t.kezdho, t.kezdnap)))
                {
                    sw.WriteLine($"{item.kezdho}.{item.kezdnap} - {item.vegho}.{item.vegnap}. {item.tabornev}");
                }
            }

            bool lehetResztVenni = true;
            foreach (var item in erdeklodes)
            {
                int elso = Sorszam(item.kezdho, item.kezdnap);
                int utolso = Sorszam(item.vegho, item.vegnap);
                int megadott = Sorszam(ho, nap);
                if (megadott >= elso && megadott <= utolso)
                {
                    lehetResztVenni = false;
                    break;
                }
            }
            if (!lehetResztVenni)
            {
                Console.WriteLine("Nem mehet el mindegyik táborba. ");
            }

            sw.Close();
            Console.ReadKey();
        }


        static int Sorszam(int ho, int nap)
        {
        
            if (ho==6)
            {
                nap = nap - 15;

            }

            if (ho==7) 
            {
                nap = nap+15;
            }

            if (ho==8)
            {
                nap = nap + 15 + 31;
            }
           
            return nap;
        }
    }
}
