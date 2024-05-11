using System;
using System.Reflection;

namespace HackatonIct
{
    public class Program
    {
        public static char DemanderUneLettreDans(string message, List<char> chars)
        {
            char letter = DemanderUneLettre(message);

            if (!chars.Contains(letter))
            {
                return DemanderUneLettreDans("ERRUER, Vous devez choisir une lettre parmis celles proposées : ", chars);
            }
            return letter;
        }
        public static int DemanderNombreEntre(string message, int min, int max)
        {
            int nombre = DemanderNombre(message);
            if (nombre < min || nombre > max)
                return DemanderNombreEntre($"\nLe nombre doit être compris entre {min} et {max} : ", min, max);
            return nombre;
        }
        public static int DemanderNombre(string message)
        {
            Console.Write(message);
            try
            {
                int number = int.Parse(Console.ReadLine());
                return number;
            }
            catch
            {
                return DemanderNombre("\nErreur, vous devez entrer un entier : ");
            }
        }
        public static string[] getPalindromesWords(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Echec du chargement du fichier : "+e.Message);
                return null;
            }
        }
        public static char DemanderUneLettre(string message)
        {
            string chiffres = "0,1,2,3,4,5,6,7,8,9";
            string alphabetMin = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,#";
            string alphabetMax = alphabetMin.ToString().ToUpper();
            string alphabet = alphabetMin + alphabetMax;

            Console.Write(message);
            string lettre = Console.ReadLine();

            //  Cas où l'utilisateur entre plusieurs lettre (un mot)
            if (lettre.Length > 1)
                return DemanderUneLettre("\nERREUR : Veuillez entrer une seule lettre : ");

            if (lettre.Length == 0)
                return DemanderUneLettre("\nERREUR : Vous devez entrer obligatoirement une lettre : ");

            if (chiffres.Contains(lettre))
                return DemanderUneLettre("\nERREUR : Vous ne pouvez entrer un chiffre, veuillez entrer une lettre : ");

            if (!alphabet.Contains(lettre))
                return DemanderUneLettre("\nERREUR : Caractere inconnu, Veuillez entrer une lettre de l'alphabet, ou # pour abandonner : ");

            lettre = lettre.ToLower();

            return lettre[0];

        }
        public static bool Palindrome(List<char> list)
        {
            var sensContraire = new List<char>();
            bool coherent = true;

            if (list.Count < 3)
                return false;

            for (int i=list.Count-1; i>=0;i--)
                sensContraire.Add(list[i]);

            for (int i = 0; i < sensContraire.Count; i++)
            {
                if (sensContraire[i] != list[i])
                {
                    coherent = false;
                }
            }

            if (coherent)
                return true;
            return false;
        }
        public static void Afficher(List<char> list)
        {
            Console.Write("Liste des caracteres déjà saisi : ");
            foreach (char c in list) 
                Console.Write(c + " ");
            Console.WriteLine("\n");
        }
        public static int ChangerLaMain(int whoCanPlay)
        {
            if (whoCanPlay == 2)
                return 1;
            return 2;
        }
        public static int GameBrute(List<char> motJoueur1, List<char> motJoueur2, int player)
        {

            Console.Clear();
            Console.WriteLine($"JOUEUR {player} : ");
            if (motJoueur1.Count>0)
                Afficher(motJoueur1);
            motJoueur1.Add(DemanderUneLettre("Entrez une lettre : "));
            if (motJoueur1.Contains('#'))
            {
                Console.WriteLine("Abandon du joueur "+player);
                return ChangerLaMain(player);
            }
            if (Palindrome(motJoueur1))
            {
                Console.WriteLine();
                foreach (char c in motJoueur1)
                { 
                    Console.Write(c + " ");
                }
                    Console.WriteLine("Est un palindrome !");
                return player;
            }

            player = ChangerLaMain(player);

            Console.Clear();
            Console.WriteLine($"JOUEUR {player} : ");
            if (motJoueur2.Count > 0)
                Afficher(motJoueur2);
            motJoueur2.Add(DemanderUneLettre("Entrez une lettre : "));
            if (motJoueur2.Contains('#'))
            {
                Console.WriteLine("Abandon du joueur " + player);
                return ChangerLaMain(player);
            }
            if (Palindrome(motJoueur2))
            {
                Console.WriteLine();
                foreach (char c in motJoueur2)
                {
                    Console.Write(c + " ");
                }
                    Console.WriteLine("Est un palindrome !");
                return player;
            }

            player = ChangerLaMain(player);

            return GameBrute(motJoueur1, motJoueur2, player);                       
        }
        public static void Start(string[] listeDesMots, int position)
        {
            Console.WriteLine($"Joueur {position}  ");
            var listJoueur1 = new List<char>();
            var listJoueur2 = new List<char>();

            listJoueur1.Add(DemanderUneLettre("Entrez une lettre : "));

            Console.WriteLine("\nFonctionnalite en attende de developpement...".ToString());
        }
        public static void GameWithBD(string[] listeDesMots)
        {
            Console.WriteLine("NB : Dans cette partie, nous avons un ensembre de mots (palindromes) déjà défini dans " +
                "une base de données, et le mot final que vous devez obtenir devra faire partie de cet ensemble " +
                "de mots\n");

            Console.WriteLine("Êtes vous d'accord pour cette configuration? ou souhaitez vous jouer " +
                            "sans une base de données de mots prédéfini ?");
            char decision = DemanderUneLettreDans("Entrez a pour 'a' pour jouer avec, ou 's' pour joueur sans (a/s) : ", new List<char> { 'a', 's'});

            if (decision ==  's')
                GameBrute(new List<char>(), new List<char>(), 1);

            Start(listeDesMots, 1);
        }
        public static void Main(string[] args)
        {
            var listeDesPalindromes = getPalindromesWords("myBD.txt");
            if (listeDesPalindromes != null)
            {
                if (listeDesPalindromes.Length == 0)
                {
                    Console.WriteLine("La base de données ne contient aucun mot, voulez vous jouer a sec ? ");
                    int decision = DemanderNombreEntre("Tapez 1 pour jouer et 2 pour sortir : ", 1, 2);

                    if (decision == 1)
                    {
                        var motJoueur1 = new List<char>();
                        var motJoueur2 = new List<char>();
                        int player = 1; // Joueur par defaut

                        int Winner = GameBrute(motJoueur1 , motJoueur2, player );

                        Console.WriteLine($"\nLe joueur {Winner} a gagné !!!".ToUpper());
                    }
                    else
                    {
                        Console.WriteLine("\nFin du programme...\n");
                    }

                }
                else
                {
                    GameWithBD(listeDesPalindromes);
                }
            }
        }
    }
}