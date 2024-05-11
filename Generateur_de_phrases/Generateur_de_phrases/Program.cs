using System;
using FormationCS;

namespace Generateur_de_phrases
{
    public class Program
    {

        public static string ObtenirElementAleatoire(string[] words)
        {
            Random rand = new Random();
            return words[rand.Next(0, words.Length)];
        }
        public static void Main(string[] args)
        {
            var sujets = new string[]
            {
                "Un lapin",
                "Une grand-mere",
                "Un chat",
                "Un bonhomme de neige",
                "Une limace",
                "Une fee",
                "Un magicien",
                "Une tortue",
            };

            var verbes = new string[]
            {
                "mange",
                "écrase",
                "détruit",
                "observe",
                "attrape",
                "regarde",
                "avale",
                "nettoie",
                "se bat avec",
                "s'accroche à"
            };

            var complements = new string[]
            {
                "un arbre",
                "un livre",
                "la lune",
                "le soleil",
                "un serpent",
                "une carte",
                "une girafe",
                "le ciel",
                "une piscine",
                "un gateau",
                "une souris",
                "un crapaud",
            };

            var listeDePhrasesUnique = new List<string>();

            int doublon = 0;

            int nombre = Outils.DemanderNombrePositifNonNull("Combien de phrase souhaitez vous générer : ");
            Console.WriteLine();

            while(listeDePhrasesUnique.Count < nombre)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complement = ObtenirElementAleatoire(complements);

                var phrase = sujet + " " + verbe + " " + complement;
                phrase = phrase.Replace("à le", "au");

                if(listeDePhrasesUnique.Contains(phrase))
                {
                    doublon += 1;
                }
                else
                {
                    listeDePhrasesUnique.Add(phrase);
                }
            }

            foreach (var sentence in listeDePhrasesUnique)
            {
                Console.WriteLine(sentence);
            }

            Console.WriteLine($"\n\nl{doublon} ont été évité");

            Console.WriteLine();
        }
    }
}