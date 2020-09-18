using System;
using System.Collections.Generic;
using System.Text;

namespace CreateClass
{
    class Room
    {

        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
        }

        public int RoomNumber;

        public static int Number { get; internal set; }
    }
}
