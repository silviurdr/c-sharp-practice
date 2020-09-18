using SerializePeople;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Silviu", new DateTime(1985,01,25), Person.Gender.Male);
            Console.WriteLine(person1);
            person1.Serialize("D:\\aicisa.bin");

            Person deserializedPerson = Person.Deserialize("D:\\aicisa.bin");

            Console.WriteLine($"The deserialized person's name is: {deserializedPerson.Age}");

        }
    }
}
