using System;
using System.Globalization;

namespace programmeDateTime
{
    class Program
    {
        public delegate string ValidationChaine(string s);
        static string DemanderChaineUtilisateur(string message, ValidationChaine fonctionValidation=null)
        {
            Console.Write(message);
            string reponse = Console.ReadLine();
            if (fonctionValidation != null)
            {
                string erreur = fonctionValidation(reponse);
                if (erreur != null)
                {
                    Console.WriteLine(erreur);
                    return DemanderChaineUtilisateur(message, fonctionValidation);
                }
            }
            return reponse;
        }
        static string CheckValidationNom(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le nom ne doit pas être vide";
            }

            if (s.Any(char.IsDigit))
            {
                return "Le nom ne doit pas contenir de chiffre";
            }

            return null;
        }

        static string CheckValidationTel(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le numéro ne doit pas être vide";
            }

            if (!(s.All(char.IsDigit)))
            {
                return "Le numéro de telephone doit contenir uniquement des chiffres";
            }

            if (!(s.Length == 9))
            {
                return "Le numéro de telephone doit avoir exactement 9 chiffres";
            }

            return null;
        }
        public static void Main(string[] args)
        {
            string nom = DemanderChaineUtilisateur("Quel est votre nom ? : ", CheckValidationNom);
            string numero = DemanderChaineUtilisateur("Quel est votre numero de téléphone ? : ", CheckValidationTel);
            Console.WriteLine();
            Console.WriteLine("Bonjour "+nom+" vous êtes joignable au "+numero);






            /*
            DateTime date = DateTime.Now;
            CultureInfo culture = CultureInfo.GetCultureInfo("fr-FR");
            Console.WriteLine(date.ToString("dddd, dd MMMM yyyy HH:mm:ss", culture));

            DateTime dateDemain = date.AddDays(365);

            var diff = dateDemain - date;

            Console.WriteLine("difference : "+diff.TotalSeconds);
            */
        }
    }
}