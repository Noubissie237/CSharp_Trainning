using System;
using System.Xml.Linq;

namespace Hello_World
{
    public class Program
    {
        public static int DemanderAge(string name)
        {
            int age = 0;

            while (age <= 0)
            {
                Console.Write("Entrez votre age de "+name+" : ");
                try
                {
                    age = int.Parse(Console.ReadLine());
                    if (age < 0)
                        Console.WriteLine("ERREUR : L'age ne doit pas être négatif ");
                    if (age == 0)
                        Console.WriteLine("ERREUR : L'age ne doit pas être égal à 0 ");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERREUR : Vous devez Entrer un age valide");
                }
            }

            return age;
        }

        public static string DemanderNom( int numéro )
        {
            string name;

            while (true)
            {
                Console.Write("Entrez votre nom de la personne numéro "+numéro+" : ");
                name = Console.ReadLine();

                if (name.Trim().Length == 0)
                {
                    Console.WriteLine("ERREUR : Le nom ne doit pas être vide");
                }
                else if (name.Trim().Length < 3)
                {
                    Console.WriteLine("ERREUR : Le nom doit contenir au moins 3 caracteres");
                }
                if (name.Trim().Length >= 3)
                    break;

            }

            return name;
        }

        public static void Afficher(string name, int age)
        {
            Console.WriteLine();
            Console.WriteLine($"Bonjour, vous vous appelez {name} et vous avez " + age + " ans");
            Console.WriteLine("Bientôt vous aurez " + (age + 1));

            if(age == 18)
                Console.WriteLine("Vous êtes tout juste majeur");
            else if (age == 17)
                Console.WriteLine("Vous serez bientôt majeur");
            else if(age >= 18 && age < 60)
                Console.WriteLine("Vous êtes majeur");
            else if (age >= 60)
                Console.WriteLine("Vous êtes sénior");
            else if (age < 10)
                Console.WriteLine("Vous êtes un enfant");
            else
                Console.WriteLine("Vous êtes mineur");
        }
        public static void Main(string[] args)
        {
            string name = DemanderNom(1);
            string name2 = DemanderNom(2);

            int age = DemanderAge(name);
            int age2 = DemanderAge(name2);

            Afficher(name, age);
            Afficher(name2, age2);

        }
    }
}