// See https://aka.ms/new-console-template for more information

namespace Day1 {
    class Member {
        private string firstName;
        private string lastName;
        private string gender;
        private DateTime dob;
        private string phone;
        private string birthPlace;
        private int age;
        private bool isGraduated;

        public Member(string firstName, string lastName, string gender, DateTime dob, string phone, string birthPlace, bool isGraduated) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.dob = dob;
            this.phone = phone;
            this.birthPlace = birthPlace;
            this.isGraduated = isGraduated;
            age = DateTime.Today.Year - dob.Year;
        }

        public string getFirstName() {
            return firstName;
        }
        public string getLastName() {
            return lastName;
        }
        public string getGender() {
            return gender;
        }
        public DateTime getDOB() {
            return dob;
        }
        public string getPhoneNum() {
            return phone;
        }
        public string getBirthPlace() {
            return birthPlace;
        }
        public int getAge() {
            return age;
        }
        public bool getIsGraduated() {
            return isGraduated;
        }
        public void setFirstName(string firstName) {
            this.firstName = firstName;
        }
        public void setLastName(string lastName) {
            this.lastName = lastName;
        }
        public void setGender(string gender) {
            this.gender = gender;
        }
        public void setDOB(DateTime dob) {
            this.dob = dob;
            age = DateTime.Today.Year - dob.Year;
        }
        public void setPhoneNum(string phone) {
            this.phone = phone;
        }
        public void setBirthPlace(string birthPlace) {
            this.birthPlace = birthPlace;
        }
        public void setIsGraduated(bool isGraduated) {
            this.isGraduated = isGraduated;
        }

        public void print() {
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Last name: " + lastName);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Date of birth: " + dob.ToString("yyyy/MM/dd"));
            Console.WriteLine("Phone number: " + phone);
            Console.WriteLine("Birth place: " + birthPlace);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Is graduated: " + (isGraduated ? "Yes" : "No"));
        }
    }

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

            foreach (Member member in members) {
                if (member.getGender() == "male") {
                    member.print();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void OldestMember(List<Member> members) {
            Member oldest = members[0];

            for (int i = 1; i < members.Count(); i++) {
                if (members[i].getDOB() < oldest.getDOB()) {
                    oldest = members[i];
                }
            }

            Console.WriteLine("This is the oldest member:");
            oldest.print();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void FullNameList(List<Member> members) {
            Console.WriteLine("This is the full name list:");
            foreach (Member member in members) {
                Console.WriteLine("Full name: " + member.getFirstName() + " " + member.getLastName());
                Console.WriteLine("Gender: " + member.getGender());
                Console.WriteLine("Date of birth: " + member.getDOB().ToString("yyyy/MM/dd"));
                Console.WriteLine("Phone number: " + member.getPhoneNum());
                Console.WriteLine("Birth place: " + member.getBirthPlace());
                Console.WriteLine("Age: " + member.getAge());
                Console.WriteLine("Is graduated: " + (member.getIsGraduated() ? "Yes" : "No"));
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        static void BirthYearList(List<Member> members) {
            List<Member> equal2k = new List<Member>();
            List<Member> over2k = new List<Member>();
            List<Member> under2k = new List<Member>();

            foreach (Member member in members) {
                switch (member.getDOB().Year) {
                    case 2000:
                        equal2k.Add(member);
                        break;
                    case >2000:
                        over2k.Add(member);
                        break;
                    default:
                        under2k.Add(member);
                        break;
                }
            }

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
            Console.WriteLine("This is the first member who was born in Ha Noi");
            Member oldest = null;
            foreach (Member member in members) {
                if (member.getBirthPlace() == "Ha Noi") {
                    if (oldest == null || member.getDOB() < oldest.getDOB()) {
                        oldest = member;
                    }
                }
            }
            if (oldest != null) {
                oldest.print();
            } else {
                Console.WriteLine("No one is born in Ha Noi.");
            }
            
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}