// See https://aka.ms/new-console-template for more information
using System.Linq;

namespace Day2 {
    
    class Program {
        static async Task Main(string[] args) {
            List<Member> members = new List<Member> {
                new Member("Thanh", "Nguyen", "male", new DateTime(2002, 10, 2), "0377628417", "Ha Noi", false),
                new Member("Mai", "Nguyen", "female", new DateTime(2000, 5, 2), "0377628417", "Ha Noi", false),
                new Member("Cuong", "Nguyen", "male", new DateTime(1955, 10, 12), "0377628417", "Nghe An", true),
                new Member("Tan", "Le", "male", new DateTime(1955, 9, 12), "0377628417", "Nghe An", true),
                new Member("Matt", "Murdock", "male", new DateTime(1988, 2, 2), "0377628417", "New York", true),
                new Member("Jennie", "Blackpink", "female", new DateTime(1997, 5, 20), "0377628417", "Seoul", true),
            };
            int choice;
            do {
                Console.WriteLine("1. Return a list of members who is Male");
                Console.WriteLine("2. Return the oldest based on \"Age\"");
                Console.WriteLine("3. Return a new list that contains Full Name only");
                Console.WriteLine("4. Return 3 lists based on birth year");
                Console.WriteLine("5. Return the first person who was born in Ha Noi");
                Console.WriteLine("6. Return prime numbers using async");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.Clear();
                switch (choice) {
                    case 1:
                        Assignments.MaleList(members);
                        break;
                    case 2:
                        Assignments.OldestMember(members);
                        break;
                    case 3:
                        Assignments.FullNameList(members);
                        break;
                    case 4:
                        Assignments.BirthYearList(members);
                        break;
                    case 5:
                        Assignments.HanoiFirstBorn(members);
                        break;
                    case 6:
                        await Assignments.PrimeNumbers();
                        break;
                    default:

                        break;
                }  
                Console.Clear();
            } while (choice != 0);
        }
    }
}