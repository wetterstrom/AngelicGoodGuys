using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace AngelicGoodGuys
{
    public enum Gender
    {
        Male,
        Female,
        NonBinary,
        Other
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
        static List<Person> list = new List<Person>();
        static void Main(string[] args)
        {

        }
    }
}
