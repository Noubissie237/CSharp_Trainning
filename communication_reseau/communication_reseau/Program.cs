using System;
using System.Net;

namespace communication_reseau
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "https://codeavecjonathan.com/res/papillon.jpg";
            var webClient = new WebClient();

            Console.WriteLine("Accès réseau...");
            try
            {
                var rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var finalPath = Path.Combine(rootPath, "img");
                string filename = "papillons.jpg";
                if (!Directory.Exists(finalPath) )
                {
                    Directory.CreateDirectory(finalPath);
                }
                var path = Path.Combine(finalPath, filename);
                webClient.DownloadFile(url, path);

                Console.WriteLine("Téléchargement réussi");
            }
            catch (WebException ex) 
            {
                if (ex.Response != null)
                {
                    var statusCode = ((HttpWebResponse)ex.Response).StatusCode;

                    if (statusCode == HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("ERREUR RESEAU : Non trouvé");
                    }
                    else
                    {
                        Console.WriteLine("ERREUR RESEAU "+statusCode);
                    }
                }
                else
                {
                    Console.WriteLine("Serveur introuvable");
                }


            }

        }
    }
}