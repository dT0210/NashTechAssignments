// See https://aka.ms/new-console-template for more information
using System.Linq;

namespace Day2 {
    
    class Program {
        static void Main(string[] args) {
            List<Member> members = new List<Member> {
                new Member("Thanh", "Nguyen", "male", new DateTime(2002, 10, 2), "0377628417", "Ha Noi", false),
                new Member("Mai", "Nguyen", "female", new DateTime(2000, 5, 2), "0377628417", "Ha Noi", false),
                new Member("Cuong", "Nguyen", "male", new DateTime(1955, 10, 12), "0377628417", "Nghe An", true),
                new Member("Tan", "Le", "male", new DateTime(1955, 9, 12), "0377628417", "Nghe An", true),
                new Member("Matt", "Murdock", "male", new DateTime(1988, 2, 2), "0377628417", "New York", true),
                new Member("Jennie", "Blackpink", "female", new DateTime(1997, 5, 20), "0377628417", "Seoul", true),
            };
            int choice = 0;
            do {
                Console.WriteLine("1. Return a list of members who is Male");
                Console.WriteLine("2. Return the oldest based on \"Age\"");
                Console.WriteLine("3. Return a new list that contains Full Name only");
                Console.WriteLine("4. Return 3 lists based on birth year");
                Console.WriteLine("5. Return the first person who was born in Ha Noi");
                Console.WriteLine("0. Exit");
                Console.Write("Your choice: ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.Clear();
                switch (choice) {
                    case 1:
                        MaleList(members);
                        break;
                    case 2:
                        OldestMember(members);
                        break;
                    case 3:
                        FullNameList(members);
                        break;
                    case 4:
                        BirthYearList(members);
                        break;
                    case 5:
                        HanoiFirstBorn(members);
                        break;
                }  
                Console.Clear();
            } while (choice != 0);
        }

        static void MaleList(List<Member> members) {
            Console.WriteLine("This is the male list:");
            var maleMembers = from member in members
                              where member.GetGender() == "male"
                              select member;
            foreach (Member member in maleMembers) {
                member.print();
                Console.WriteLine();
            }

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void OldestMember(List<Member> members) {
            Member? oldest = members.MaxBy(member => member.GetAge());

            Console.WriteLine("This is the oldest member:");
            if (oldest != null) oldest.print();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void FullNameList(List<Member> members) {
            var fullNameList = members.Select(member => member.GetFirstName() + " " + member.GetLastName());

            Console.WriteLine("This is the full name list:");
            foreach (string name in fullNameList) {
                Console.WriteLine(name);
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void BirthYearList(List<Member> members) {
            var equal2k = from member in members
                          where member.GetDOB().Year == 2000
                          select member;
            var over2k = from member in members
                          where member.GetDOB().Year > 2000
                          select member;
            var under2k = from member in members
                          where member.GetDOB().Year < 2000
                          select member;


            Console.WriteLine("List of members who have the birth year of 2000:");
            foreach(Member member in equal2k) {
                member.print();
                Console.WriteLine();
            }
            Console.WriteLine("List of members who have the birth year greater than 2000:");
            foreach(Member member in over2k) {
                member.print();
                Console.WriteLine();
            }
            Console.WriteLine("List of members who have the birth year less than 2000:");
            foreach(Member member in under2k) {
                member.print();
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void HanoiFirstBorn(List<Member> members) {
            var bornInHN = from member in members
                            where member.GetBirthPlace() == "Ha Noi"
                            select member;
            Member? first = bornInHN.OrderBy(member => member.GetDOB()).First();
            if (first != null) {
                Console.WriteLine("This is the first member who was born in Ha Noi");
                first.print();
            } else {
                Console.WriteLine("No one is born in Ha Noi.");
            }
            
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}