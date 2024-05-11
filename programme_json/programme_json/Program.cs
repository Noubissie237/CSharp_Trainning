using Newtonsoft.Json;
using System;

namespace programme_json
{
    public class Person
    {
        public string nom {  get; init; }
        public int age { get; init; }
        public bool majeur {  get; init; }

        public Person(string nom, int age, bool majeur)
        {
            this.nom = nom;
            this.age = age;
            this.majeur = majeur;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom : {this.nom}\nAge : {this.age} ans");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*var person1 = new Person("Toto", 20, true);
            person1.Afficher();

            var noms = new List<string>() { "Noubissie", "Kamga", "Wilfried" };
            var nomSeria = JsonConvert.SerializeObject(noms);
            Console.WriteLine(nomSeria);

            string json = JsonConvert.SerializeObject(person1);
            string test = "{ \"nom\":\"NK\",\"age\":23,\"majeur\":true}";

            var person2 =  JsonConvert.DeserializeObject<Person>(test);
            person2.Afficher();*/

            /*var peoplesList = new List<Person>()
            {
                new Person("Noubissie", 23, true),
                new Person("Makou", 19, false),
                new Person("Sinclair", 20, false),
                new Person("Gloria", 21, true)
            };

            var peopleListSerialize = JsonConvert.SerializeObject(peoplesList);

            File.WriteAllText("personnes.txt", peopleListSerialize);*/

            var listeDePersonne = File.ReadAllText("personnes.txt");

            var peoples = JsonConvert.DeserializeObject<List<Person>>(listeDePersonne);

            foreach ( Person person in peoples )
            {
                person.Afficher();
                Console.WriteLine();
            }
        }
    }
}