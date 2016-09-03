using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    class Clyde:Unit
    {
        private Pacman p;
        public Clyde(Labirint l, Pacman p):this(l, p, new Vector2D()){}
        public Clyde(Labirint l, Pacman p, Vector2D position):base(l, position)
        {
            this.p = p;
        }
        protected override ConsoleColor unitColor
        {
            get
            {
                return ConsoleColor.Yellow;
            }
        }
        public override void Move()
        {
            previousPosition = position;
            previousDirection = direction;
            Vector2D endPosition = new Vector2D(p.position.X, p.position.Y);
            if(Math.Abs(position.X - p.position.X) < 9 || Math.Abs(position.Y - p.position.Y) < 9)
                endPosition = new Vector2D(l.Width, l.Heigth);
            Path clydePath = PathFinder.FindPath(l, position, endPosition);
            Vector2D a = clydePath[1] - clydePath[0];
            direction = Vector2D.Step.FindByValue(a);
            base.Move();
        }
    }
}
