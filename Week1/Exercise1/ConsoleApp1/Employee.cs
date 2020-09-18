using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    internal class Employee: Person, ICloneable
    {
        public Employee(string name, DateTime dateTime, int v1, string v2) : base(name, dateTime)
        {
            V1 = v1;
            V2 = v2;
        }

        public Employee(string name, DateTime dateTime, string profession, int salary, Room roomNumber) : base(name, dateTime)
        {

            Profession = profession;
            Salary = salary;
            RoomNumber = roomNumber;
        }

        public int Salary { get; set; }
        public string Profession { get; set; }
        public Room RoomNumber { get; private set; }
        public int V1 { get; }
        public string V2 { get; }
        public Room Room { get; internal set; }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.RoomNumber = new Room(Room.Number);
            return newEmployee;
        }

        public override string ToString()
        {
            return $"{Name} is a {Profession} and earns {Salary:C} and he is in room {RoomNumber.RoomNumber}";
        }

 

    }
}
