using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatShouldIEat
{
    class Program
    {
        static void Main(string[] args)
        {
            WhatToEat wte = new WhatToEat();
            foreach (var item in wte.GetAllFoods())
            {
                Console.WriteLine(item.Name);
            }

            Console.Read();
        }
    }
}
