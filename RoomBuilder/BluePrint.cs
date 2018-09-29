using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomBuilder
{
    public static class BluePrint
    {
        //Changeable
        public static char RoomFiller = '█';

        //Don't make less than 3 or it will break
        public static int maxWidth = 99;
        public static int minWidth = 1;
        public static int maxRooms = 6;


        //Don't change
        public static int minRooms = 3;
        public static int numOfRooms;
        public static int totalHeight;
        public static int totalWidth;
        public static int greatestWidth = 0;
        public static int greenHeightCount = 0;
        public static List<Room> rooms = new List<Room>();
        public static List<ConsoleColor> colors = new List<ConsoleColor>() {
            ConsoleColor.Blue,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.White,
            ConsoleColor.Cyan
        };

        public static void Start()
        {
            numOfRooms = AskNumQuestion($"How many Rooms ({minRooms}-{maxRooms}): ", minRooms, maxRooms);
            for (int i = 0; i < numOfRooms - 1; i++)
            {
                var height = AskNumQuestion($"Height of room {i + 1}: ", minWidth, maxWidth);
                var width = AskNumQuestion($"Width of room {i + 1}: ", minWidth, maxWidth);
                var room = new Room() { Color = colors[i], Height = height, Width = width, Number = i + 1};
                rooms.Add(room);
                totalHeight += room.Height;
                if (greatestWidth < room.Width)
                    greatestWidth = room.Width;
            }

            totalWidth = greatestWidth + AskNumQuestion("Main room width: ", 3, maxWidth);

            Build();
        }


        private static void Build()
        {
            for(int i = 0; i < numOfRooms - 1; i++)
            {
                BuildRoom(rooms[i]);
            }
        }

        private static int AskNumQuestion(string question, int min, int max)
        {
            Console.WriteLine(question);
            var result = 0;
            while(!int.TryParse(Console.ReadLine(), out result) || result < min || result > max)
            {
                Console.Clear();
                Console.WriteLine($"Please Enter a Number ({min}-{max})");
                Console.WriteLine(question);
            }
            Console.Clear();
            return result;
        }

        private static void BuildRoom(Room room)
        {
            for (int i = 0; i < room.Height; i++)
            {
                if (i == (room.Height / 2))
                {
                    Console.ForegroundColor = room.Color;
                    Squares(room.Width / 2);
                    Console.Write(room.Number);
                    Squares(room.Width / 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Squares(totalWidth - room.Width);
                    Console.WriteLine();
                    greenHeightCount++;
                    continue;
                }
                else if (greenHeightCount == totalHeight / 2)
                {
                    Console.ForegroundColor = room.Color;
                    Squares(room.Width);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Squares((totalWidth - room.Width) / 2);
                    Console.Write(numOfRooms);
                    Squares((totalWidth - room.Width) / 2);
                    Console.WriteLine();
                    greenHeightCount++;
                    continue;
                }
                Console.ForegroundColor = room.Color;
                Squares(room.Width);
                Console.ForegroundColor = ConsoleColor.Green;
                Squares((totalWidth - room.Width));
                Console.WriteLine();
                greenHeightCount++;
            }
        }
        private static void Squares(int length)
        {
            Console.Write(new String(RoomFiller, length));
        }
    }
}
