using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    class Inky:Unit
    {
        private Pacman p;
        public Inky(Labirint l, Pacman p):this(l, p, new Vector2D()){}
        public Inky(Labirint l, Pacman p, Vector2D position):base(l, position)
        {
            this.p = p;
        }
        protected override ConsoleColor unitColor
        {
            get
            {
                return ConsoleColor.Cyan;
            }
        }
        public override void Move()
        {
            previousPosition = position;
            previousDirection = direction;
            Vector2D middlePosition = p.position + Vector2D.Step[p.direction];
            Vector2D endPosition = this.position + 2 * (middlePosition - this.position);
            Path InkyPath = PathFinder.FindPath(l, position, endPosition);
            Vector2D a = InkyPath[1] - InkyPath[0];
            direction = Vector2D.Step.FindByValue(a);
            base.Move();
        }
    }
}
