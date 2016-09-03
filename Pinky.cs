using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    class Pinky:Unit
    {
        private Pacman p;
        public Pinky(Labirint l, Pacman p):this(l, p, new Vector2D()){}
        public Pinky(Labirint l, Pacman p, Vector2D position):base(l, position)
        {
            this.p = p;
        }
        protected override ConsoleColor unitColor
        {
            get
            {
                return ConsoleColor.Magenta;
            }
        }
        public override void Move()
        {
            previousPosition = position;
            previousDirection = direction;
            Vector2D endPosition = new Vector2D(p.position.X, p.position.Y);
            switch(p.direction)
            {
                case Direction.UP:
                    endPosition += Vector2D.Step[Direction.LEFT] + Vector2D.Step[Direction.UP];
                    break;
                case Direction.DOWN:
                    endPosition += Vector2D.Step[Direction.DOWN];
                    break;
                case Direction.LEFT:
                    endPosition += Vector2D.Step[Direction.LEFT];
                    break;
                case Direction.RIGHT:
                    endPosition += Vector2D.Step[Direction.RIGHT];
                    break;
                default:
                    break;
            }
            Path pinkyPath = PathFinder.FindPath(l, position, endPosition);
            Vector2D a = pinkyPath[1] - pinkyPath[0];
            direction = Vector2D.Step.FindByValue(a);
            base.Move();
        }
    }
}

