using System;

namespace Курсовой
{
    public enum Direction
    {
        NULL, RIGHT, LEFT, UP, DOWN
    }

    abstract class Unit
    {
        public Vector2D position;
        public Direction direction;
        protected Labirint l;
        protected Vector2D previousPosition;
        protected Direction previousDirection;
        public Unit(): this(null, null, Direction.NULL) { }
        public Unit(Labirint l, Vector2D position) : this(l, position, Direction.NULL) { }
        public Unit(Labirint l, Vector2D position, Direction direction)
        {
            this.l = l;
            this.previousPosition = this.position = position;
            this.previousDirection = this.direction = direction;
        }
        public virtual void Move()
        {
            if (previousDirection == direction)
                this.position += Vector2D.Step[direction];
            else
                previousDirection = direction;
        }
        protected virtual ConsoleColor unitColor
        {
            get
            {
                return ConsoleColor.White;
            }
        }
        protected virtual char symbol
        {
            get
            {
                return '@';
            }
        }
        public void Show()
        {
            int count = 0;
            foreach (var berry in l.berries)
            {
                if (berry.position == previousPosition)
                {
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Console.SetCursorPosition(previousPosition.X, previousPosition.Y);
                Console.Write(' ');
            }
            Console.ForegroundColor = unitColor;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(symbol);
            Console.SetCursorPosition(0, l.Heigth + 2);
        }
    }
}
