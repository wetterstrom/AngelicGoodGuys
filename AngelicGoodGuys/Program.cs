using System;
using System.Collections.Generic; // Används för List<>
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
        public string Length { get; set; }
        public string Color { get; set; }

    }


    // Klassen person som innehåller alla egenskaper för en person
    public class Person
    {
        public Gender Gender { get; set; }
        public Hair Hair { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EyeColor { get; set; }

        // Metod för att få en snygg textsträng som representerar personen
        public override string ToString()
        {
            return $"Kön: {Gender}\n" +
                   $"Hår: {Hair.Color}, {Hair.Length}\n" +
                   $"Födelsedag: {DateOfBirth.ToShortDateString()}\n" +
                   $"Ögonfärg: {EyeColor}";
        }
    }

    class Program
    {
        // Lista för att lagra alla personer
        static List<Person> List = new List<Person>();
        static void Main(string[] args)
        {
            // Skapar en variabel som styr om programmet ska fortsätta köra
            bool isRunning = true;

            // Huvudloop som körs tills användaren väljer att avsluta
            while (isRunning)
            {
                // Startmeny för användaren
                Console.WriteLine("EVIL EAVESDROPPERS INC.");
                Console.WriteLine("1. Lägg till person");
                Console.WriteLine("2. Se en lista med alla personer");
                Console.WriteLine("3. Avsluta programmet");

                // Läser in användarens val från menyn som representerades ovan
                string choice = Console.ReadLine();

                // Switch-sats för att hantera användarens val
                switch (choice)
                {
                    case "1":
                        // Anropar metoden för att lägga till en person
                        AddPerson();
                        break;

                    case "2":
                        // Anropar metoden för att lista alla personer
                        ListPersons();
                        break;

                    case "3":
                        // Avslutar programmet genom att sätta variabeln isRunning till false
                        Console.WriteLine("Avslutar programmet");
                        isRunning = false;
                        break;

                    default:
                        // Hanterar ogiltiga val
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;

                }
            }
        }
        // Metod för att lägga till en person
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

            // Skapar en ny instans av Hair och lägger till den i personen
            Hair newHair = new Hair();
            Console.WriteLine("Ange hårfärg:");
            newHair.Color = Console.ReadLine();
            Console.WriteLine("Ange hårlängd:");
            newHair.Length = Console.ReadLine();
            newPerson.Hair = newHair;

            // Läser in födelsedatum och konverterar det till DateTime
            Console.WriteLine("Ange födelsedatum (ÅÅÅÅ-MM-DD):");
            string dobInput = Console.ReadLine();
            if (DateTime.TryParse(dobInput, out DateTime dob))
            {
                newPerson.DateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Felaktigt datumformat. Försök igen.");
                return; // Avslutar metoden om datumet är felaktigt
            }

            Console.WriteLine("Ange ögonfärg:");
            newPerson.EyeColor = Console.ReadLine();

            // Lägger till den nya personen i listan
            List.Add(newPerson);
            Console.WriteLine("Person tillagd!");

        }
        // Metod för att lista alla personer
        static void ListPersons()
        {
            Console.WriteLine("Lista över alla personer:");

            // Loopar igenom varje person i listan och skriver ut deras information
            foreach (Person p in List)
            {
                // Anropar ToString-metoden för att få en snygg representation av personen
                Console.WriteLine(p.ToString());
                Console.WriteLine("---------------------");
            }
        }
    }
}
