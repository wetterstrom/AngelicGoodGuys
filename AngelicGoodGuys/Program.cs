using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace AngelicGoodGuys
{
    public enum Gender
    {
        Man,
        Kvinna,
        Annat

    }

    public struct Hair
    {
        // Make fields public properties and correct spelling
        public string Length { get; set; }
        public string Color { get; set; }

    }



    public class Person
    {
        public Gender Gender { get; set; }
        public Hair Hair { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EyeColor { get; set; }

        public override string ToString()
        {
            return $"Gender: {Gender}\n" +
                   $"Hair: {Hair.Color}, {Hair.Length}\n" +
                   $"Birthday: {DateOfBirth.ToShortDateString()}\n" +
                   $"Eye color: {EyeColor}";
        }
    }

    class Program
    {
        static List<Person> List = new List<Person>();
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("EVIL EAVESDROPPERS INC.");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Se en lista med alla personer");
                Console.WriteLine("3. Avsluta programmet");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPerson();
                        break;

                    case "2":
                        ListPersons();
                        break;

                    case "3":
                        Console.WriteLine("Avslutar programmet");
                        isRunning = false;
                        break;

                }
            }
        }
        static void AddPerson()
        {
            Person newPerson = new Person();
            Console.WriteLine("Du ska nu få ge signalement för personen");
            Console.WriteLine("Ange kön. Skriv '0' för Man, '1' för Kvinna, '2' för Annat:");
            string GenderInput = Console.ReadLine();
            newPerson.Gender = GenderInput switch { "0" => Gender.Man, "1" => Gender.Kvinna, "2" => Gender.Annat };

            if (0 != int.Parse(GenderInput) && 1 != int.Parse(GenderInput) && 2 != int.Parse(GenderInput))
            {
                Console.WriteLine("Felaktig inmatning för kön. Försök igen.");
                return;
            }

            Hair newHair = new Hair();
            Console.WriteLine("Ange hårfärg:");
            newHair.Color = Console.ReadLine();
            Console.WriteLine("Ange hårlängd:");
            newHair.Length = Console.ReadLine();
            newPerson.Hair = newHair;

            Console.WriteLine("Ange födelsedatum (ÅÅÅÅ-MM-DD):");
            string dobInput = Console.ReadLine();
            if (DateTime.TryParse(dobInput, out DateTime dob))
            {
                newPerson.DateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Felaktigt datumformat. Försök igen.");
                return;
            }

        }
        static void ListPersons()
        {
            Console.WriteLine("Lista över alla personer:");
            foreach (Person p in List)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("---------------------");
            }
        }
    }
}
