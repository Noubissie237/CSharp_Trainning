using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKbibliotheque
{
    static internal class NK
    {
        public static int DemanderNombrePositifNonNull(string message)
        {
            int nombre = DemanderNombre(message);
            if (nombre > 0)
                return nombre;
            return DemanderNombrePositifNonNull("\nLe nombre doit etre superieur a zéro (0) : ");
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
    }
}
