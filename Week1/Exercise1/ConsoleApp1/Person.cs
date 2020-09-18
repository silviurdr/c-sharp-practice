using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    class Person
    {


        public Person(string name, DateTime dateTime)
        {
            Name = name;
            this.BirthDate = dateTime;
        }

        public DateTime BirthDate;

        public string Name { get; set; } = "Empty";

        enum Genders
        {
            Male,
            Female
        }

        public override string ToString()
        {
            return $"{Name} + {BirthDate.Year} + {Genders.Male}";
        }


    }
}
