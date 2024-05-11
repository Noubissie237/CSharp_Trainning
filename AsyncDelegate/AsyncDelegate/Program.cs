using System;
using System.Net;

namespace AsyncDelegate
{
    public class Program
    {
        static bool downloading = false;
        public static void Main(string[] args)
        {
            var webClient = new WebClient();

            Console.Write("Téléchargement...");
            string url = "https://codeavecjonathan.com/res/bateau.jpg";
            downloading = true;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(url), "bateau.jpg");

            while (downloading)
            {
                Thread.Sleep(500);
                if (downloading)
                    Console.Write(".");
            }
            Console.WriteLine("FIN DU PROGRAMME");
        }

        private static void WebClient_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("OK");
            downloading = false;
        }
    }
}