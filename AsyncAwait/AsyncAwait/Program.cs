using System;

namespace AsyncAwait
{
    public class Program
    {
        public static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
        public static async Task<string> DownloadData(string url)
        {
            var httpClient = new HttpClient();

            string result = await httpClient.GetStringAsync(url);
            Console.WriteLine("OK -> " + url);
            return result;
        }
        public static async Task Main(string[] args)
        {
            string url1 = "https://codeavecjonathan.com/res/dummy.txt";
            string url2 = "https://codeavecjonathan.com/res/pizzas1.json";

            Console.Write("Téléchargement...");
            DisplayProgress();

            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            await Task.WhenAll(downloadTask1, downloadTask2);
            Console.WriteLine("FIN DU PROGRAMME");
        }

    }
}