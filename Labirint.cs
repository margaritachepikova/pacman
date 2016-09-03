using System;
using System.Collections.Generic;
using System.IO;

namespace Курсовой
{
    [Serializable]
    class Labirint
    {
        int[,] myArr;
        public readonly Dictionary<string, Vector2D> startPoint = new Dictionary<string, Vector2D>();
        public readonly Dictionary<string, Vector2D> portalPoints = new Dictionary<string, Vector2D>();
        public List<Berry> berries = new List<Berry>();
        public int Width
        {
            get { return myArr.GetLength(0); }
        }
        public int Heigth
        {
            get { return myArr.GetLength(1); }
        }
        public int this[int index1, int index2]
        {
            get { return myArr[index1, index2]; }
        }
        public Labirint()
        {
            //string[] lines = global::Курсовой.Properties.Resources.Level1.
            //    Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] lines;
            string path = @"C:\Users\Маргарита\Desktop\Курсовой\Resources\Level1.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                lines = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }
            myArr = new int[lines[0].Length, lines.Length];
            for(int i = 0; i < myArr.GetLength(0); i++)
            {
                for(int j = 0; j < myArr.GetLength(1); j++)
                {
                    if (lines[j][i] == '$')
                        berries.Add(new Berry(i, j));
                    if (lines[j][i] == '#')
                        myArr[i, j] = -1;
                    else if (lines[j][i] == '*')
                        myArr[i, j] = -2;
                    else if (lines[j][i] == '%')
                        myArr[i, j] = -3;
                    else
                        myArr[i, j] = 0;
                }
            }
            for (int i = 0; i < myArr.GetLength(0); i++)
            {
                for (int j = 0; j < myArr.GetLength(1); j++)
                {
                    if (lines[j][i] == 'b')
                        startPoint.Add("blinky", new Vector2D(i, j));
                    if (lines[j][i] == 'p')
                        startPoint.Add("pinky", new Vector2D(i, j));
                    if (lines[j][i] == 'i')
                        startPoint.Add("inky", new Vector2D(i, j));
                    if (lines[j][i] == 'c')
                        startPoint.Add("clyde", new Vector2D(i, j));
                    if (lines[j][i] == 'l')
                        portalPoints.Add("leftPortal", new Vector2D(i, j));
                    if (lines[j][i] == 'r')
                        portalPoints.Add("rightPortal", new Vector2D(i, j));
                }
            }
        }
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < myArr.GetLength(0); i++)
            {
                for (int j = 0; j < myArr.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    if (myArr[i, j] < 0 && myArr[i, j] > -4)
                        Console.Write('#');
                    else
                        Console.Write(" ");
                }
            }
        }
        public void OpenGate()
        {
            for (int i = 0; i < myArr.GetLength(0); i++)
            {
                for (int j = 0; j < myArr.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);
                    if (myArr[i, j] == -2)
                    {
                        myArr[i, j] = 0;
                        Console.Write(' ');
                    }
                    if (myArr[i, j] == -3)
                        myArr[i, j] = -1;
                }
            }
        }
    }
}
