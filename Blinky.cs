using System;
using System.Collections.Generic;

namespace Курсовой
{
    class Blinky: Unit
    {
        private Pacman p;
        public Blinky(Labirint l, Pacman p) : this(l, p, new Vector2D()){}
        public Blinky(Labirint l, Pacman p, Vector2D position ):base(l, position)
        {
            this.p = p;
        }
        protected override ConsoleColor unitColor
        {
            get
            {
                return ConsoleColor.Red;
            }
        }
        public override void Move()
        {
            previousPosition = position;
            previousDirection = direction;
            Path blinkyPath = PathFinder.FindPath(l, position, p.position);
            Vector2D a = blinkyPath[1] - blinkyPath[0];
            direction = Vector2D.Step.FindByValue(a);
            base.Move();
        }
    }
}