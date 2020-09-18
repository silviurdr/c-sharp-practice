using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{

    [Serializable]
    public class Person: IDeserializationCallback, ISerializable
    {

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        [NonSerialized]
        public int Age;

        public int GetMyProperty()
        {
            return this.Age;
        }

        public void SetMyProperty(int value)
        {
            this.Age = value;
        }

        public Gender PersonGender { get; set; }

        public enum Gender
        {
            Male,
            Female
        }
        public Person(string name, DateTime birthDate, Gender gender)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.PersonGender = gender;
            this.Age = CalculateAge(birthDate);
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        public void Serialize(string output)
        {
            // Create file to save the data
            // Create and use a BinaryFormatter object to perform the serialization
            // Close the file

            if (File.Exists(output))
            {
                File.Delete(output);
                Console.WriteLine("File deleted.");
            }
            else
            {
                Console.WriteLine("File not found");
            }

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static Person Deserialize(string filePath)
        {

            Person person;
            // notice that Person should have a default constructor
            // Open file to read the data from
            // Create a BinaryFormatter object to perform the deserialization
            // Use the BinaryFormatter object to deserialize the data from the file
            // Close the file and return with the brand-new Person object

            using FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                person = (Person)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }

            return person;
        }

        public override string ToString()
        {
            return $"This is the person {Name}, gender {PersonGender}, age {Age}, born on {BirthDate}.";
        }

        public void OnDeserialization(object sender)
        {
            var today = DateTime.Today;
            var age = today.Year - this.BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            this.Age = age;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", this.Name);
            info.AddValue("birthDate", this.BirthDate);
            info.AddValue("gender", this.PersonGender);
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            this.Name = (string)info.GetValue("name", typeof(Person));
            this.BirthDate = (DateTime)info.GetValue("birthDate", typeof(Person));
            this.PersonGender = (Gender)info.GetValue("gender", typeof(Person));
        }
    }
}
