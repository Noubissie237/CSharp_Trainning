using System;

namespace POO
{
    public class Enfant : Etudiant
    {
        string classEcole;
        Dictionary<string, float> notes;
        public Enfant(string nom, int age, string classEcole, Dictionary<string, float> notes) : base (nom, age, null)
        {
            this.classEcole = classEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNomAge();
            Console.WriteLine("   Enfant en classe de " + this.classEcole);
            if (notes != null && notes.Count > 0)
            {
                Console.WriteLine("Notes moyennes");    
                foreach (var note in notes)
                {
                    Console.WriteLine($"    {note.Key} : {note.Value} / 10");
                }
            }
            AfficherProfesseurPrincipal();
        }
    }
    public class Etudiant : Person
    {
        string infoEtudes;
        public Person professeurPrincipal { get; init; }
       
        public Etudiant(string nom, int age, string infoEtud) : base(nom, age)
        {
            this.infoEtudes = infoEtud;
        }

        public override void Afficher()
        {
            AfficherNomAge();
            Console.WriteLine("   Etudiant en "+this.infoEtudes);
            AfficherProfesseurPrincipal();
        }

        protected void AfficherProfesseurPrincipal()
        {
            if (this.professeurPrincipal != null)
            {
                Console.WriteLine("Le professeur principale est : ");
                this.professeurPrincipal.Afficher();
            }
        }
    }
    public class Person : iAffichage
    {
        private static int nombreDePersonne = 0;
        public string nom { get; init; }
        public int age {  get; init; }
        string profession;
        protected int numeroPersonne;

        public Person(string nom, int age, string profession = null)
        {
            this.nom = nom;
            this.age = age;
            this.profession = profession;
            nombreDePersonne++;
            this.numeroPersonne = nombreDePersonne;
        }

        protected void AfficherNomAge()
        {
            Console.WriteLine("Personne n°" + numeroPersonne);
            Console.WriteLine("   NOM : " + this.nom);
            Console.WriteLine("   AGE : " + this.age);
        }
        public virtual void Afficher()
        {
            AfficherNomAge();

            if (this.profession != null) 
                Console.WriteLine("   PROFESSION : "+this.profession);
            else
                Console.WriteLine("   PROFESSION : (non spécifé)");
            Console.WriteLine();
        }

        public static void AfficherNombrePersonne()
        {
            Console.WriteLine($"Il y'a actuellement {nombreDePersonne} personne(s)");
        }


    }
    
    public class TableMultiplication : iAffichage
    {
        int nombre;
        public TableMultiplication(int nombre)
        {
            this.nombre = nombre;
        }
        public void Afficher()
        {
            Console.WriteLine("Table de multiplication de "+this.nombre);
            for (int i = 0; i <= 10; i++)
                Console.WriteLine($"{nombre} x {i} = {nombre*i}");
        }
    }

    interface iAffichage
    {
        void Afficher();
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var elements = new List<iAffichage>
            {
                new Person("Paul", 23, "Développeur"),
                new Person("Jackques", 23, "Professeur"),
                new Etudiant("David", 20, "philo"),
                new Enfant("Juliette", 06, "CP", new Dictionary<string, float>
                {
                    {"Lecture", 15f },
                    {"Dictée", 17f }
                }),
                new TableMultiplication(5)
            };

            //elements = elementstmp.Where(x => (x.nom[0] == 'J' && x.age > 20)).ToList();

            foreach (var element in elements)
            {
                element.Afficher();
            }

           /* var t = new TableMultiplication(5);
            t.Afficher();*/

        }
    }
}