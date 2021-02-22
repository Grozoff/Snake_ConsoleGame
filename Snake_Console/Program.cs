using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake_Console
{
    class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
#pragma warning restore CA1416 // Validate platform compatibility

            // Рамка
            Walls walls = new Walls(80, 25);
            walls.Draw();            

            // Змейка
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // Еда
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();


            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail() )
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    snake.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }

        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset + 1, yOffset++);
            WriteText("G A M E    O V E R", xOffset + 6, yOffset++);
            yOffset++;
            WriteText("Create by: Sergey Grozov", xOffset + 2, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText (string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}