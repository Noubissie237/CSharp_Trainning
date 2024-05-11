using FormationCS;
using System;

namespace Password_Générator
{

    public class Programm
    {
        public static void Main(string[] args)
        {
            string minuscule = "abcdefghijklmnopqrstuvwxyz";
            string majuscule = minuscule.ToUpper();
            string chiffre = "0123456789";
            string caracteres = "#&+-_";
            const int NB_MOT_DE_PASSE = 10;
            string alphabetFinal = "";

            Random rand = new Random();

            int longueur = Outils.DemanderNombreEntre("Longueur du mot de passe : ", 4, 16);

            Console.WriteLine("Voulez vous un mot de passe avec : ");
            Console.WriteLine("1. Uniquement des caractères en minuscule");
            Console.WriteLine("2. Des caractères minuscule et majuscules");
            Console.WriteLine("3. Des caractères et des chiffres");
            Console.WriteLine("4. Caractères, chiffres et caractères spéciaux");

            int choix = Outils.DemanderNombreEntre("Votre choix : ", 1, 4);

            switch (choix)
            {
                case 1 :
                    alphabetFinal += minuscule;
                    break;
                case 2 :
                    alphabetFinal += minuscule + majuscule;
                    break;
                case 3 :
                    alphabetFinal += minuscule + majuscule + chiffre;
                    break;
                case 4 :
                    alphabetFinal += minuscule + majuscule + chiffre + caracteres;
                    break;
                default:
                    break;
            }

            for(int j = 0; j < NB_MOT_DE_PASSE; j++)
            {
                string motDePass = "";

                for (int i = 0; i < longueur; i++)
                {
                    int indice = rand.Next(0, alphabetFinal.Length);

                    motDePass += alphabetFinal[indice];
                }

                Console.WriteLine("Mot de passe : "+motDePass);
            }

        }
    }
}