using System;
namespace ASP_.Net_Core_Fundamental.Models
{
    public class Person
    {
        //private string _fullname;
        //private int _age;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthPlace { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth;
        public bool IsGraduated { set; get; }
        public int Age {set;get;}
        // {
        //     get
        //     {
        //         int year = CalculateAgeCorrect(DateOfBirth, DateTime.Now);
        //         return year;
        //     }
        //     set
        //     {
        //         _age = value;
        //     }
        // }
        public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return Age;
        }
    }
}