using System;
using System.Collections.Generic;

namespace Курсовой
{
    class Game
    {
        Labirint l;
        Pacman gamer1;
        Dictionary<string, Unit> ghosts;

        public void Start()
        {
            l = new Labirint();
            SerDeserTemlate<Labirint>.Serialize(@"C:\Users\Маргарита\Desktop\Курсовой\Resources\Serialize.txt", l);
            SerDeserTemlate<Labirint>.Deserialize(@"C:\Users\Маргарита\Desktop\Курсовой\Resources\Serialize.txt");
            gamer1 = new Pacman(l, new Vector2D(1, 1));
            ghosts = new Dictionary<string, Unit>
            {
                { "blinky", new Blinky(l, gamer1, l.startPoint["blinky"]) },
                { "pinky",  new Pinky(l, gamer1, l.startPoint["pinky"]) },
                { "inky", new Inky(l, gamer1, l.startPoint["inky"])},
                { "clyde", new Clyde(l, gamer1, l.startPoint["clyde"]) }
            };
            int count = 0;
            l.Show();
            while (!IsLose())
            {
                if (count > 10)
                    l.OpenGate();
                DoStep();
                Show();
                count++;
                if(IsWin())
                {
                    Console.WriteLine("You win!!!");
                    break;
                }
            }
        }

        private void DoStep()
        {
            gamer1.Move();
            foreach (var ghost in ghosts)
                ghost.Value.Move();
        }

        private void Show()
        {
            foreach (var berry in l.berries)
                berry.Show();
            gamer1.Show();
            foreach (var ghost in ghosts)
                ghost.Value.Show();
        }

        public void Stop() { }

        private bool IsLose()
        {
            foreach (var ghost in ghosts)
                if (ghost.Value.position == gamer1.position)
                {
                    Console.WriteLine("You lose!!!");
                    return true;
                }
            return false;
        }
        private bool IsWin()
        {
            int count = 0;
            foreach (var berry in l.berries)
            {
                if (berry.position == new Vector2D(0, 0))
                {
                    count++;
                }
            }
            return l.berries.Count == count;
        }
    }
}
