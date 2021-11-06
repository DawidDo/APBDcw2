namespace cw2.Models
{
    public class Student
    {
        public string FirstName { get; set;  }
        public string LastName { get; set; }
        public string Kierunek { get;  set; }
        public string Tryb { get; set; }
        public string Number { get; set; }
        public string Data { get; set; }
        public string Mail { get; set; }
        public string Ojciec { get; set; }
        public string Matka { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName &&
                   Number == student.Number;
        }
        

        public override int GetHashCode()
        {
            return (FirstName + LastName + Number).GetHashCode();
        }
    }
}