

namespace Day2 {
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

        public string GetFirstName() {
            return firstName;
        }
        public string GetLastName() {
            return lastName;
        }
        public string GetGender() {
            return gender;
        }
        public DateTime GetDOB() {
            return dob;
        }
        public string GetPhoneNum() {
            return phone;
        }
        public string GetBirthPlace() {
            return birthPlace;
        }
        public int GetAge() {
            return age;
        }
        public bool GetIsGraduated() {
            return isGraduated;
        }
        public void SetFirstName(string firstName) {
            this.firstName = firstName;
        }
        public void SetLastName(string lastName) {
            this.lastName = lastName;
        }
        public void SetGender(string gender) {
            this.gender = gender;
        }
        public void SetDOB(DateTime dob) {
            this.dob = dob;
            age = DateTime.Today.Year - dob.Year;
        }
        public void SetPhoneNum(string phone) {
            this.phone = phone;
        }
        public void SetBirthPlace(string birthPlace) {
            this.birthPlace = birthPlace;
        }
        public void SetIsGraduated(bool isGraduated) {
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
}