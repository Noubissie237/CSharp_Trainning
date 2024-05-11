using System;

namespace Manip
{

    public class Program
    {
        public static void ManipDeTest()
        {
            var etudiants = new Dictionary<string, string>();
            
            while (true)
            {
                Console.Write("Entrer le numéro (ou -1 pour quitter) : ");
                string num = Console.ReadLine();
                while (!(int.TryParse(num, out int nums)))
                {
                    Console.Write("Entrez un numéro valide (ou -1 pour quitter) : ");
                    num = Console.ReadLine();
                }

                if (int.Parse(num) == -1)
                {
                    break;
                }

                Console.Write("Entrer un nom : ");
                string name = Console.ReadLine();

                etudiants.Add(num, name);
                Console.WriteLine();
            }

            etudiants = etudiants.OrderBy(x => x.Value).ToDictionary();

            Console.WriteLine(" -------------- AFFICHAGE DE LA LISTE --------------");
            foreach( var elt in etudiants)
            {
                Console.WriteLine(elt);
            }

            Console.WriteLine(" -------------- AFFICHAGE DES ETUDIANT AYANT UNE SIM ORANGE --------------");
            var etuOrange = etudiants.Where(elt => (elt.Key[1] - '0')==9 || ((elt.Key[1] - '0') == 5 && (elt.Key[2] - '0') >= 5));
            foreach (var elt in etuOrange)
            {
                Console.WriteLine(elt);
            }

            Console.WriteLine(" -------------- AFFICHAGE DES ETUDIANT AYANT UNE SIM MTN --------------");
            var etuMTN = etudiants.Where(elt => (elt.Key[1] - '0') == 7 || (elt.Key[1] - '0') == 8 || ((elt.Key[1] - '0') == 5  && (elt.Key[2] - '0') < 5));
            foreach (var elt in etuMTN)
            {
                Console.WriteLine(elt);
            }
        }
        public static void Main(string[] args)
        {
            ManipDeTest();
        }
    }
}