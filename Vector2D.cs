using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовой
{
    [Serializable]
    class Vector2D
    {
        public int X;
        public int Y;
        public Vector2D(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Vector2D(): this(0, 0) { }
        public static Dictionary<Direction, Vector2D> Step;
        static Vector2D()
        {
            Step = new Dictionary<Direction, Vector2D> {
                { Direction.RIGHT, new Vector2D(1, 0) },
                { Direction.LEFT, new Vector2D(-1, 0) },
                { Direction.DOWN, new Vector2D(0, 1) },
                { Direction.UP, new Vector2D(0, -1) },
                { Direction.NULL, new Vector2D(0, 0) }
            };
        }
        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }
        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }
        public static Vector2D operator *(Vector2D a, int i)
        {
            return new Vector2D(a.X * i, a.Y * i);
        }
        public static Vector2D operator *(int i, Vector2D a)
        {
            return new Vector2D(a.X * i, a.Y * i);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Vector2D b;
            if ((b = obj as Vector2D) == null)
                return false;
            return (this.X == b.X && this.Y == b.Y);

        }
        public static bool operator ==(Vector2D a, Vector2D b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Vector2D a, Vector2D b)
        {
            return !a.Equals(b);
        }
    }

    public static class DictionaryExtension
    {
        public static TKey FindByValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value)
        {
            TKey d = default(TKey);
            List < TKey > keyList = new List<TKey>(dictionary.Keys);
            foreach (TKey key in keyList)
            {
                if (EqualityComparer<TValue>.Default.Equals(dictionary[key], value))
                {
                    d = key;
                }
            }
            return d;
        }
    }
}
