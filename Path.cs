using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    class Path
    {
        List<Vector2D> List;
        
        public Path()
        {
            this.List = new List<Vector2D> ();
        }

        public Vector2D this[int index]
        {
            get { return List[index]; }
        }

        public int Count
        {
            get { return List.Count; }
        }

        public void Add(Vector2D a)
        {
            if(List.Count == 0)
            {
                List.Add(a);
                return;
            }
            if(!Contains(a) && IfCanAdd(a))
                List.Add(a);
        }

        public bool Contains(Vector2D a)
        {
            foreach(var item in List)
            {
                if (item.Equals(a))
                    return true;
            }
            return false;
        }

        public bool IfCanAdd(Vector2D a)
        {
            if (List[List.Count - 1].X == a.X && (List[List.Count - 1].Y - a.Y == 1 || List[List.Count - 1].Y - a.Y == -1))
                return true;

            else if (List[List.Count - 1].Y == a.Y && (List[List.Count - 1].X - a.X == 1 || List[List.Count - 1].X - a.X == -1))
                return true;

            else
                return false;
        } 

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in List)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write('#');
            }
        }
    }
}
