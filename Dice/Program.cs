using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleDice myDice = new SimpleDice();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(myDice.Dice());
            }
            Console.Read();
        }
    }
}
