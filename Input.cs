using System;
using System.Collections.Generic;

namespace Курсовой
{
    static class Input
    {
        public static Dictionary<ConsoleKey, Direction> keyDirection;
        
        static Input()
        {
            keyDirection = new Dictionary<ConsoleKey, Direction>{
                { ConsoleKey.DownArrow, Direction.DOWN },
                { ConsoleKey.UpArrow, Direction.UP },
                { ConsoleKey.LeftArrow, Direction.LEFT },
                { ConsoleKey.RightArrow, Direction.RIGHT }
            };
        }
        public static Direction GetDirection()
        {
            if (keyDirection.ContainsKey(Console.ReadKey().Key))
                return keyDirection[Console.ReadKey().Key];
            else
                return Direction.NULL;
        }
    }
}
