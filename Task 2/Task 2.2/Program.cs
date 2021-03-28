using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();
            Console.WriteLine("Enter E for start game (control - wasd)");
            Console.WriteLine("Another button exit");
            ConsoleKey key = Console.ReadKey().Key;
            do
            {
                world.Create_World();
                if (world.Play())
                {
                    Console.Clear();
                    Console.WriteLine("You Win!!!");
                    Console.WriteLine("Enter E for restart game (control - wasd)");
                    Console.WriteLine("Another button exit");
                    key = Console.ReadKey().Key;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You dead!!!");
                    Console.WriteLine("Enter E for restart game (control - wasd)");
                    Console.WriteLine("Another button exit");
                    key = Console.ReadKey().Key;
                }
            } while (key == ConsoleKey.E);
            Console.ReadKey();
        }
    }

    public class World
    {
        private Map map;
        private Player player;
        private List<Enemy> enemies;
        private List<Bonus> bonuses;

        public void Create_World()
        {
            map = new Map(10, 10);
            player = new Player(2, 2, 3);
            enemies = new List<Enemy>();
            enemies.Add(new Enemy(8, 8, 10, 1));
            enemies.Add(new Enemy(2, 8, 10, 1));
            enemies.Add(new Enemy(8, 2, 10, 1));
            enemies.Add(new Enemy(6, 6, 10, 1));
            bonuses = new List<Bonus>();
            bonuses.Add(new Bonus(1, 9));
            bonuses.Add(new Bonus(1, 1));
            bonuses.Add(new Bonus(8, 5));
            bonuses.Add(new Bonus(9, 9));
        }

        public bool Play()
        {
            Random random = new Random();
            map.Draw_Map(player, enemies, bonuses);
            do
            {
                player.Set_Free(map.Enviroment(player.X, player.Y));

                player.Input();

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (player.X == enemies[i].X && player.Y == enemies[i].Y)
                    {
                        player.HPController(enemies[i].Damage);
                        enemies.RemoveAt(i);
                    }
                }

                for (int i = 0; i < bonuses.Count; i++)
                {
                    if (player.X == bonuses[i].X && player.Y == bonuses[i].Y)
                    {
                        bonuses.RemoveAt(i);
                    }
                }

                foreach (var enemy in enemies)
                {
                    enemy.Set_Free(map.Enviroment(enemy.X, enemy.Y));
                    enemy.Random_Direction(random.Next(0, 2), random.Next(-1, 2));
                }

                map.Draw_Map(player, enemies, bonuses);

                if (player.HP == 0)
                {
                    player = null;
                }
            } while (player != null && bonuses.Count > 0);
            if (player == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class Map
    {
        private int height;
        private int width;
        private char[,] map;
        public Map(int h, int w)
        {
            height = h;
            width = w;
            map = new char[10, 10]
            {
                {' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ' },
                {' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ' },
                {'#', '#', '#', '#', ' ', ' ', '#', ' ', ' ', ' ' },
                {' ', ' ', ' ', '#', ' ', ' ', '#', ' ', ' ', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };
        }

        public void Draw_Map(Player player, List<Enemy> enemies, List<Bonus> bonuses)
        {
            Console.Clear();
            for (int h = -1; h <= height; h++)
            {
                for (int w = -1; w <= width; w++)
                {
                    if (h == -1 || w == -1 || h == height || w == width)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        char icon = ' ';
                        bool draw = true;
                        if (h == player.Y && w == player.X)
                        {
                            icon = player.Icon;
                            draw = false;
                        }
                        foreach (var enemy in enemies)
                        {
                            if (h == enemy.Y && w == enemy.X)
                            {
                                icon = enemy.Icon;
                                draw = false;
                                break;
                            }
                        }
                        foreach (var bonus in bonuses)
                        {
                            if (h == bonus.Y && w == bonus.X)
                            {
                                icon = bonus.Icon;
                                draw = false;
                                break;
                            }
                        }
                        if (draw)
                        {
                            Console.Write(map[h, w]);
                        }
                        else
                        {
                            Console.Write(icon);
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Health player: " + player.HP);
            Console.WriteLine("Bonuses to win: " + bonuses.Count);
        }
        
        public bool[] Enviroment(int x, int y)
        {
            bool[] res = new bool[4] { false, false, false, false};
            if (y > 0 && map[y - 1, x] == ' ')
            {
                res[0] = true;
            }
            if (y < height - 1 && map[y + 1, x] == ' ')
            {
                res[2] = true;
            }
            if (x < width - 1 && map[y, x + 1] == ' ')
            {
                res[1] = true;
            }
            if (x > 0 && map[y, x - 1] == ' ')
            {
                res[3] = true;
            }
            return res;
        }
    }


}
