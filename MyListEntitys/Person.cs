using System;
using System.Collections;

namespace MyListEntitys
{
    public class Person : IComparable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int Age { get; set; }
        public int PostCode { get; set; }
        public int Svnr { get; set; }

        public Person()
            : this("noName", "noName", 0, 0, 0)
        {

        }
        public Person(string firstName, string lastName, int age, int postCode, int svnr)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PostCode = postCode;
            Svnr = svnr;
        }

        public static IComparer SortOnAgeDescending()
        {
            throw new NotImplementedException();
        }
        public static IComparer SortOnPostCodeDescending()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object other)
        {
            throw new NotImplementedException();
        }
    }
}
