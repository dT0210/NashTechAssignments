

namespace Day2 {
    public class Member {
        public string firstName {get; set;}
        public string lastName {get; set;}
        public string gender {get; set;}
        private DateTime dob {get; set;}
        public DateTime DOB {
            get {return dob;}
            set {
                dob = value;
                age = DateTime.Today.Year - dob.Year;
            }
        }
        public string phone {get; set;}
        public string birthPlace {get; set;}
        public int age;
        public bool isGraduated {get; set;}

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
}