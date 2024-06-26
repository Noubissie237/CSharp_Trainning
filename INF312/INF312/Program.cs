﻿using ScottPlot;

namespace INF312
{
    public class Program
    {
        public static string GetFilename(string path, int firstId)
        {
            string filename = "img"+firstId+".jpg";
            
            filename = Path.Combine(path, filename);

            if (File.Exists(filename))
            {
                firstId += 1;
                return GetFilename(path, firstId);
            }
            Console.WriteLine("Image sauvegardée : img"+firstId+".jpg");
            return filename;

        }
        public static List<string[]> GetData(string path, string filename)
        {
            var data = new List<string[]>();
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(path, filename)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        data.Add(fields);
                    }

                }
                data.RemoveAt(0);
                foreach (var field in data)
                {
                    field[0] = field[0].Replace('-', ' ');
                    field[0] = field[0].Replace('/', ' ');
                }

                return data;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
                return null;
            }
        }

        public static void SavePicture(string filename, List<string[]> data, string title, string xLabel, string yLabel)
        {
            var dataX = new List<string>();
            var dataY = new List<string>();

            var plt = new Plot();

            foreach (var elt in data)
            {
                dataX.Add(elt[0]);
                dataY.Add(elt[1].Split('.')[0]);
            }

            plt.Add.Scatter(dataX, dataY);

            plt.Title(title);
            plt.XLabel(xLabel);
            plt.YLabel(yLabel);

            plt.Save(filename, 900, 800);

        }
        public static void FinalFunction(string path, int id, List<string[]> data, string title, string xLabel, string yLabel)
        {
            string filename = GetFilename(path, id);
            SavePicture(filename, data, title, xLabel, yLabel);
        }
        public static void Main(string[] args)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "INF312_IMG");
            var pathDataset = "N:\\UY1\\L3\\S02\\INF312(STAT)\\Nzekon\\Devoirs\\devoirNzekong";
            
            var data1 = GetData(pathDataset, "AirPassengers.csv");
            var data2 = GetData(pathDataset, "annual_rainfall_dallas.csv");
            var data3 = GetData(pathDataset, "monthly-sunspots.csv");
            var data4 = GetData(pathDataset, "Electric_Production.csv");
            var data5 = GetData(pathDataset, "BTC-EUR.csv");


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FinalFunction(path, 1, data1, "Air passengers", "Années", "Nombre de passager");
            FinalFunction(path, 1, data2, "annual_rainfall_dallas", "Années", "Nombre de pluie");
            FinalFunction(path, 1, data3, "Monthly-sunspots", "Années", "Sunspots");
            FinalFunction(path, 1, data4, "Electric_Production", "Date", "IPG");
            FinalFunction(path, 1, data5, "BTC-EUR", "Date", "BTC");

            Console.WriteLine($"Image générée avec succès dans {path}");
        }
    }
}