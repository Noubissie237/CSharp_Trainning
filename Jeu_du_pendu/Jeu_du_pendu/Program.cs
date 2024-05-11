using System;
using NKbibliotheque;
using Jeux;
using System.Runtime.CompilerServices;

namespace Jeu_du_pendu
{
    public class Program
    {
        public static string[] ChargerMots(string nomFichier)
        {
            try
            {
               return File.ReadAllLines(nomFichier);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Erreur de lecture du fichier : {ex.Message}");
            }
            return null;
        }
        public static void AfficherMot(string mot, List<char> lettres)
        {
            for(int i = 0; i < mot.Length; i++)
            {
                if (lettres.Contains(mot[i]))
                    Console.Write(mot[i] + " ");
                else
                    Console.Write("_ ");
            }
        }

        public static void DevinerMot(string mot)
        {
            var lettresDevines = new List<char>();
            var mauvaisesLettres = new List<char>();

            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while (viesRestantes > 0)
            {
                Console.WriteLine(Bonhomme.PENDU[NB_VIES-viesRestantes]); 
                AfficherMot (mot, lettresDevines);
                Console.WriteLine();
                char lettre = NK.DemanderUneLettre("\nVeuillez entre une lettre : ");
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    lettresDevines.Add(lettre);
                    if(ToutesLettreDevines(mot, lettresDevines))
                    {
                        AfficherMot(mot, lettresDevines);
                        Console.WriteLine("\n\nGAGNE !!!");
                        break;
                    }
                }
                else
                {
                    if (!(mauvaisesLettres.Contains(lettre)))
                    {
                        mauvaisesLettres.Add(lettre);
                        viesRestantes -= 1;
                    }
                    
                    Console.WriteLine($"Vie(s) restante(s) : {viesRestantes}");
                   
                }
                
                if (mauvaisesLettres.Count > 0)
                {
                    Console.WriteLine("Le mot ne contient pas les lettres : " + String.Join(", ", mauvaisesLettres));
                    Console.WriteLine();
                }

            }
            if (viesRestantes == 0)
            {
                Console.WriteLine(Bonhomme.PENDU[NB_VIES]);
                Console.WriteLine($"\nPERDU ! le mot étais {mot}");
            }
        }

        public static bool ToutesLettreDevines(string mot, List<char> lettres)
        {
            foreach (char lettre in lettres)
            {
                if (mot.Contains(lettre))
                    mot = mot.Replace(lettre.ToString(), "");
            }
            if (mot.Length == 0)
                return true;
            return false;
        }

        public static bool DemanderDeRejouer(string message)
        {
            char decision = NK.DemanderUneLettre(message);

            if ((decision.ToString().ToLower() != "o") && (decision.ToString().ToLower() != "n"))
                return DemanderDeRejouer("ERREUR : Veuillez choisir 'o' pour rejouer et 'n' pour arreter : ");

            if (decision.ToString().ToLower() == "o")
            {
                Console.Clear();
                return true;
            }
            Console.WriteLine("Merci, à bientôt !");
            return false;
        }
        public static void Main(string[] args)
        {
            var mots = ChargerMots("pays.txt");

            if (mots == null || mots.Length == 0)
            {
                Console.WriteLine("La liste de mots est vide");
            }
            else
            {
                bool jouer = true;
                while(jouer)
                {
                    var rand = new Random();
                    int position = rand.Next(mots.Length);
                    string mot = mots[position].Trim().ToUpper();
                    DevinerMot(mot);

                    jouer = DemanderDeRejouer("Voulez vous rejouer ? (o / n) : ");
                }
            }


        }
    }
}