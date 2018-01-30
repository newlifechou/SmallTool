using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class SimpleDice
    {
        private Random rand;

        public SimpleDice()
        {
            rand = new Random();
        }

        public int Dice()
        {
            return rand.Next(1, 6);
        }

    }
}
