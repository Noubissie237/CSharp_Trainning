using System;
using System.ComponentModel;

namespace MagicNumber
{
    public class MagicNumber
    {
        enum Operateur
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3,
            DIVISION = 4,
        }
        public static bool poserQuestion(int NOMBRE_MIN, int NOMBRE_MAX)
        {
            int reponseInt = 0;
            int resultatAttentdu; 
            Random rand = new Random();

            int a = rand.Next(NOMBRE_MIN, (NOMBRE_MAX + 1));
            int b = rand.Next(NOMBRE_MIN, (NOMBRE_MAX + 1));
            Operateur o = (Operateur)rand.Next(1, 5);

            while (true)
            {


                switch (o)
                {
                    case Operateur.ADDITION:
                        Console.Write($"{a} + {b} = ");
                        resultatAttentdu = a + b;
                        break;

                    case Operateur.MULTIPLICATION:
                        Console.Write($"{a} * {b} = ");
                        resultatAttentdu = a * b;
                        break;

                    case Operateur.SOUSTRACTION:

                        Console.Write($"{a} - {b} = ");
                        resultatAttentdu = a - b;
                        break;

                    case Operateur.DIVISION:
                        Console.Write($"{a} / {b} = ");
                        resultatAttentdu = a / b;
                        break;

                    default:
                        Console.WriteLine("Erreur : Opérateur inconnu !");
                        return false;

                }

                string reponse = Console.ReadLine();

                try
                {
                    reponseInt = int.Parse(reponse);
                    break;
                }
                catch
                {
                    Console.WriteLine("Erreur : vous devez entrer un nombre");
                }
            }

            if (reponseInt == resultatAttentdu)
                return true;
            return false;
        }
        public static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            const int nbQuestion = 5;
            int points = 0;

            for(int i = 0; i < nbQuestion; i++)
            {
                Console.WriteLine($"Question n° {i+1} / {nbQuestion} : ");

                bool bonneReponse = poserQuestion(NOMBRE_MIN, (NOMBRE_MAX + 1));

                if (bonneReponse)
                {
                    points += 1;
                    Console.WriteLine("Bonne reponse");
                }
                else
                    Console.WriteLine("Mauvaise reponse");
                Console.WriteLine();
            }

            Console.WriteLine($"Nombre de points :  {points} / {nbQuestion}");

            int moyenne = nbQuestion / 2;

            if (points == nbQuestion)
                Console.WriteLine("Excellent ! ");
            else if (points == 0)
                Console.WriteLine("Revisez vos maths ! ");
            else if (points > moyenne)
                Console.WriteLine("Pas mal !");
            else if (points <= moyenne)
                Console.WriteLine("Peut mieux faire");


        }
    }
}