using System;

namespace Курсовой
{
    [Serializable]
    class Berry
    {
        public Vector2D position;

        public Berry(int x, int y)
        {
            position = new Vector2D(x, y);
        }

        public void Show()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("*");
            Console.SetCursorPosition(0, 0);
        }
    }
}
