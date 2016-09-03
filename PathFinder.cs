namespace Курсовой
{
    static class PathFinder
    {
        public static Path FindPath(Labirint gameField, Vector2D a, Vector2D b)
        {
            Path shortestPath = new Path();
            int i = 1;
            int[,] arr = new int[gameField.Width, gameField.Heigth];

            for (int x = 0; x < gameField.Width; x++)
                for (int y = 0; y < gameField.Heigth; y++)
                    arr[x, y] = gameField[x, y];
            if (!(b.X > 0 && b.X < gameField.Width && b.Y > 0 && b.Y < gameField.Heigth))
            {
                if (b.X < 0)
                    b.X = 0;
                if (b.X > gameField.Width - 1)
                    b.X = gameField.Width - 1;
                if (b.Y < 0)
                    b.Y = 0;
                if (b.Y > gameField.Heigth - 1)
                    b.Y = gameField.Heigth - 1;
            }
            if (arr[b.X, b.Y] != 0)
            {
                int tempX = 0;
                int tempY = 0;
                int x = b.X;
                int y = b.Y;
                int c = 0;
                while (c == 0)
                {
                    if (x > 0 && arr[x - 1, y] == 0)
                    {
                        tempX = x - 1;
                        tempY = y;
                        c++;
                    }
                    if (x < gameField.Width - 1 && arr[x + 1, y] == 0)
                    {
                        tempX = x + 1;
                        tempY = y;
                        c++;
                    }
                    if (y > 0 && arr[x, y - 1] == 0)
                    {
                        tempX = x;
                        tempY = y - 1;
                        c++;
                    }
                    if (y < gameField.Heigth - 1 && arr[x, y + 1] == 0)
                    {
                        tempX = x;
                        tempY = y + 1;
                        c++;
                    }

                    if (c == 0)
                    {
                        if (x > 0)
                        {
                            tempX = x - 1;
                            tempY = y;
                        }
                        if (x < gameField.Width - 1)
                        {
                            tempX = x + 1;
                            tempY = y;
                        }
                        if (y > 0)
                        {
                            tempX = x;
                            tempY = y - 1;
                        }
                        if (y < gameField.Heigth - 1)
                        {
                            tempX = x;
                            tempY = y + 1;
                        }

                    }
                    x = tempX;
                    y = tempY;
                }
                b.X = x;
                b.Y = y;
            }
            arr[b.X, b.Y] = 1;
            int count = 0;
            while (arr[a.X, a.Y] == 0)
            {
                count = 0;
                for (int x = 0; x < gameField.Width; x++)
                    for (int y = 0; y < gameField.Heigth; y++)
                    {
                        if (arr[x, y] == i)
                        {
                            if (x > 0 && (arr[x - 1, y] == 0 || arr[x - 1, y] < -1))
                            {
                                arr[x - 1, y] = i + 1;
                                count++;
                            }
                            if (y > 0 && (arr[x, y - 1] == 0 || arr[x, y - 1] < -1))
                            {
                                arr[x, y - 1] = i + 1;
                                count++;
                            }
                            if (x < gameField.Width - 1 && (arr[x + 1, y] == 0 || arr[x + 1, y] < -1))
                            {
                                arr[x + 1, y] = i + 1;
                                count++;
                            }
                            if (y < gameField.Heigth - 1 && (arr[x, y + 1] == 0 || arr[x, y + 1] < -1))
                            {
                                arr[x, y + 1] = i + 1;
                                count++;
                            }
                        }
                    }

                i++;
            }

            //Console.WriteLine();
            //for (int y = 0; y < gameField.Heigth; y++)
            //{
            //    for (int x = 0; x < gameField.Width; x++)
            //    {
            //        Console.Write(arr[x, y] == -1 ? "#  " : arr[x, y].ToString() + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            shortestPath.Add(a);

            int t = a.X;
            int v = a.Y;
            int tx = 0;
            int ty = 0;
            i = arr[a.X, a.Y];
            count = 0;
            while (true)
            {
                count = 0;
                if (t > 0 && arr[t - 1, v] == i - 1 && gameField[t - 1, v] == 0)
                {
                    tx = t - 1;
                    ty = v;
                    count++;
                }
                if (v > 0 && arr[t, v - 1] == i - 1 && gameField[t, v - 1] == 0)
                {
                    tx = t;
                    ty = v - 1;
                    count++;
                }
                if (t < gameField.Width - 1 && arr[t + 1, v] == i - 1 && gameField[t + 1, v] == 0)
                {
                    tx = t + 1;
                    ty = v;
                    count++;
                }
                if (t < gameField.Heigth - 1 && arr[t, v + 1] == i - 1 && gameField[t, v + 1] == 0)
                {
                    tx = t;
                    ty = v + 1;
                    count++;
                }

                if (count == 0)
                    break;
                shortestPath.Add(new Vector2D(tx, ty));
                t = tx;
                v = ty;
                i--;
            }

            if (shortestPath.Count < 2)
            {
                if (t > 0 && gameField[t - 1, v] == 0)
                {
                    tx = t - 1;
                    ty = v;
                }
                if (v > 0 && gameField[t, v - 1] == 0)
                {
                    tx = t;
                    ty = v - 1;
                }
                if (t < gameField.Width - 1 && gameField[t + 1, v] == 0)
                {
                    tx = t + 1;
                    ty = v;
                }
                if (t < gameField.Heigth - 1 && gameField[t, v + 1] == 0)
                {
                    tx = t;
                    ty = v + 1;
                }

                shortestPath.Add(new Vector2D(tx, ty));
            }
            return shortestPath;
        }
    }
}
