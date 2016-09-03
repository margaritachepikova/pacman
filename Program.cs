using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vector2D s = new Vector2D();
            //s = s * 5;
            //Labirint l = new Labirint();
            //l.Show();
            //Path p1 = PathFinder.FindPath(l, new Vector2D(11, 14), new Vector2D(1, 1));
            //p1.Show();

            Game g = new Game();
            g.Start();
        }
    }
}
