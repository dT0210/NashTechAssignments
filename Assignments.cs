namespace Day2 {
    public static class Assignments {
        
        public static void MaleList(List<Member> members) {
            Console.WriteLine("This is the male list:");
            var maleMembers = from member in members
                              where member.gender == "male"
                              select member;
            foreach (Member member in maleMembers) {
                member.print();
                Console.WriteLine();
            }

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public static void OldestMember(List<Member> members) {
            Member? oldest = members.MaxBy(member => member.age);

            Console.WriteLine("This is the oldest member:");
            if (oldest != null) oldest.print();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public static void FullNameList(List<Member> members) {
            var fullNameList = members.Select(member => member.firstName + " " + member.lastName);

            Console.WriteLine("This is the full name list:");
            foreach (string name in fullNameList) {
                Console.WriteLine(name);
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public static void BirthYearList(List<Member> members) {
            var equal2k = from member in members
                          where member.DOB.Year == 2000
                          select member;
            var over2k = from member in members
                          where member.DOB.Year > 2000
                          select member;
            var under2k = from member in members
                          where member.DOB.Year < 2000
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

        public static void HanoiFirstBorn(List<Member> members) {
            var bornInHN = from member in members
                            where member.birthPlace == "Ha Noi"
                            select member;
            Member? first = bornInHN.OrderBy(member => member.DOB).First();
            if (first != null) {
                Console.WriteLine("This is the first member who was born in Ha Noi");
                first.print();
            } else {
                Console.WriteLine("No one is born in Ha Noi.");
            }
            
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        public static async Task PrimeNumbers() {
            Console.Write("Start from: ");
            int.TryParse(Console.ReadLine(), out int start);
            Console.Write("End at: ");
            int.TryParse(Console.ReadLine(), out int end);

            List<Task> taskList = new();
            
            List<int> primes = new List<int>();
            foreach (var i in Enumerable.Range(start, end-start+1)) {
                taskList.Add(Task.Run(() => {
                    if (IsPrime(i)) primes.Add(i);
                }));
            }
            

            await Task.WhenAll(taskList);
            foreach (var prime in primes) {
                Console.Write(prime + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        static bool IsPrime(int number) {
            if (number <= 1) return false;
            if (number <= 3) return true;
            for (int i = 2; i <= Math.Sqrt(number); i++) {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}