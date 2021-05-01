using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console0105Dz
{
    class Fighter
    {
        public int Health;
        public int Damage;
        private int _number;

        public Fighter(int health, int damage, int number, int x, int y, char symbol, ConsoleColor color)
        {
            Health = health;
            Damage = damage;
            _number = number;
        }

        public void ShowStatistic()
        {
            Console.WriteLine($"Боец {_number}: Здоровье - {Health}, Наносимый урон - {Damage}");
        }
    }

    class Program
    {
        static void Fight(ref bool isExit, Fighter player1, Fighter player2)
        {
            Console.Clear();
            player1.ShowStatistic();
            player2.ShowStatistic();

            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.Q:
                    player2.Health -= player1.Damage;
                    if (player2.Health <= 0)
                        isExit = true;
                    Console.Clear();
                    player1.ShowStatistic();
                    player2.ShowStatistic();
                    break;
                case ConsoleKey.P:
                    player1.Health -= player2.Damage;
                    if (player2.Health <= 0)
                        isExit = true;
                    Console.Clear();
                    player1.ShowStatistic();
                    player2.ShowStatistic();
                    break;
                case ConsoleKey.Escape:
                    isExit = true;
                    break;
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            Fighter player1 = new Fighter(100, random.Next(7, 10), 1, 5, 15, '@', ConsoleColor.Red);
            Fighter player2 = new Fighter(100, random.Next(7, 10), 2, 15, 15, '@', ConsoleColor.Blue);

            bool isExit = false;

            while (isExit != true)
                Fight(ref isExit, player1, player2);
        }
    }
}
