using System;
using System.Text;

namespace NombreMagic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = "out";
            var filename = "monfichier.txt";
            
            if (!Directory.Exists(repository))
            {
                Directory.CreateDirectory(repository);
            }
            var path = Path.Combine(repository, filename);

            StringBuilder text = new StringBuilder();

            // ----------------------------------------------------
            /*          DateTime t1 = DateTime.Now;

                        Console.Write("Préparation des données...");

                        for (int i = 0; i < 20000000; i++)
                            text.Append("Ligne" + (i + 1) + "\n");

                        Console.WriteLine("OK");

                        Console.Write("Ecriture des données...");

                        File.WriteAllText(path, text.ToString());

                        Console.WriteLine("OK");

                        DateTime t2 = DateTime.Now;

                        var diff = (int)(t2 - t1).TotalMilliseconds;

                        Console.WriteLine("Durée (s) : "+diff);*/

            // ----------------------------------------------------

            DateTime t1 = DateTime.Now;
            Console.Write("Ecriture des données...");
            using (var writeScream = File.CreateText(path))
            {
                for (int i = 0; i < 10000; i++)
                    writeScream.WriteLine("Ligne" + (i + 1));
            }
            Console.WriteLine("OK...");

            using (var readScream = File.OpenText(path))
            {
                while (true)
                {
                    var line = readScream.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine(line);
                }
            }


            DateTime t2 = DateTime.Now;

            var diff = (int)(t2 - t1).TotalMilliseconds;
            Console.WriteLine("Durée (s) : " + diff);
        }
    }
}