using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    class Pacman: Unit
    {
        public Pacman(Labirint l, Vector2D position) : this(l, position, Direction.NULL) {}
        public Pacman(Labirint l, Vector2D position, Direction direction) : base(l, position, direction) {}
        protected override ConsoleColor unitColor
        {
            get
            {
                return ConsoleColor.Yellow;
            }
        }
        protected override char symbol
        {
            get
            {
                char ch = '∙';

                switch (direction)
                {
                    case Direction.NULL:
                        ch = '∙';
                        break;
                    case Direction.LEFT:
                        ch = '>';
                        break;
                    case Direction.RIGHT:
                        ch = '<';
                        break;
                    case Direction.UP:
                        ch = 'v';
                        break;
                    case Direction.DOWN:
                        ch = '^';
                        break;
                    default:
                        break;
                }
                if (previousPosition == l.portalPoints["leftPortal"] && direction == Direction.NULL)
                    ch = '>';
                if (previousPosition == l.portalPoints["rightPortal"] && direction == Direction.NULL)
                    ch = '<';
                return ch;
            }
        }
        public override void Move()
        {
            int count = -1;
            previousPosition = position;
            previousDirection = direction;
            Direction nextDirection = Input.GetDirection();
            Vector2D nextPosition = position + Vector2D.Step[nextDirection];
            if (position == l.portalPoints["leftPortal"] && nextDirection == Direction.LEFT)
            {
                position = l.portalPoints["rightPortal"];
                direction = Direction.NULL;
            }
            else if (position == l.portalPoints["rightPortal"] && nextDirection == Direction.RIGHT)
            {
                position = l.portalPoints["leftPortal"];
                direction = Direction.NULL;
            }
            else if (l[nextPosition.X, nextPosition.Y] == 0)
                direction = nextDirection;
            else
                direction = Direction.NULL;
            base.Move();
            foreach (var berry in l.berries)
            {
                count++;
                if (berry.position == position)
                {
                    break;
                }
            }
            if (count >= 0)
            {
                l.berries.RemoveAt(count);
            }
        }
    }
}
