using System;
using System.Collections.Generic;
using System.Text;

namespace RoomBuilder
{
    public static class BluePrint
    {
        //These numbers will change what the room looks like
        //Besides the fact that it contains three polygons :)
        //Note: The height is 2x bigger than the width, visually.
        public static int blueRoomHeight = 5; //Odd numbers work better
        public static int blueRoomWidth = 11; //Odd numbers work better

        public static int redRoomHeight = 5; //Odd numbers work better
        public static int redRoomWidth = 11; //Odd numbers work better

        public static int greenRoomWidth = 11; //Odd numbers work better

        //Don't change
        public static int totalHeight = blueRoomHeight + redRoomHeight;
        public static int totalWidth = (blueRoomWidth > redRoomWidth) ? greenRoomWidth + blueRoomWidth : greenRoomWidth + redRoomWidth;
        public static int greenHeightCount = 0;

        public static void Build()
        {
            BuildRoom(ConsoleColor.Blue, blueRoomWidth, blueRoomHeight);
            BuildRoom(ConsoleColor.Red, redRoomWidth, redRoomHeight);
        }
        public static void BuildRoom(ConsoleColor color, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                if (i == (height / 2))
                {
                    Console.ForegroundColor = color;
                    Squares(width / 2);
                    Console.Write(1);
                    Squares(width / 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Squares(totalWidth - width);
                    Console.WriteLine();
                    greenHeightCount++;
                    continue;
                }
                else if (greenHeightCount == totalHeight / 2)
                {
                    Console.ForegroundColor = color;
                    Squares(width);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Squares((totalWidth - width) / 2);
                    Console.Write(2);
                    Squares((totalWidth - width) / 2);
                    Console.WriteLine();
                    greenHeightCount++;
                    continue;
                }
                Console.ForegroundColor = color;
                Squares(width);
                Console.ForegroundColor = ConsoleColor.Green;
                Squares((totalWidth - width));
                Console.WriteLine();
                greenHeightCount++;
            }
        }
        public static void Squares(int length)
        {
            Console.Write(new String('█', length));
        }
    }
}
