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
            HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            // Змейка
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            
            while(true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(100);
                snake.Move();
            }
            
        }
    }
}