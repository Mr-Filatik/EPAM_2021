using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Bonus
    {
        private int coordinate_x;
        private int coordinate_y;
        //private int value;
        private char icon;
        public int X { get { return coordinate_x; } }
        public int Y { get { return coordinate_y; } }
        //public int Value { get { return value; } }
        public char Icon { get { return icon; } }

        public Bonus(int v_x, int v_y /*,int v*/)
        {
            coordinate_x = v_x;
            coordinate_y = v_y;
            //value = v;
            icon = 'B';
        }
    }

    public class Being
    {
        private int coordinate_x;
        private int coordinate_y;
        private int hp;
        private char icon;
        private bool[] free;
        public int X { get { return coordinate_x; } }
        public int Y { get { return coordinate_y; } }
        public int HP { get { return hp; } }
        public char Icon { get { return icon; } }

        public Being(int v_x, int v_y, int v_hp, char v_i)
        {
            coordinate_x = v_x;
            coordinate_y = v_y;
            hp = v_hp;
            icon = v_i;
        }

        public void Move(int vertical, int horizontal)
        {
            if ((free[0] == true && vertical < 0)||(free[2] == true && vertical > 0))
            {
                coordinate_y += vertical;
            }
            if ((free[1] == true && horizontal > 0) || (free[3] == true && horizontal < 0))
            {
                coordinate_x += horizontal;
            }
        }

        public void Set_Free(bool[] f)
        {
            free = f;
        }

        public void HPController(int d)
        {
            hp -= d;
            if(hp < 0)
            {
                hp = 0;
            }
        }
    }

    public class Enemy : Being
    {
        private int damage;
        public int Damage { get { return damage; } }

        public Enemy(int x, int y, int hp, int d) : base(x, y, hp, 'E')
        {
            damage = d;
        }

        public void Random_Direction(int a, int b)
        {
            if (a == 0)
            {
                Move(b, 0);
            }
            else
            {
                Move(0, b);
            }
        }
    }

    public class Player : Being
    {
        public Player(int x, int y, int hp) : base(x, y, hp, 'P')
        {
            
        }

        public void Input()
        {
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.W)
            {
                Move(-1, 0);
            }
            if (key == ConsoleKey.S)
            {
                Move(1, 0);
            }
            if (key == ConsoleKey.D)
            {
                Move(0, 1);
            }
            if (key == ConsoleKey.A)
            {
                Move(0, -1);
            }
        }
    }
}
