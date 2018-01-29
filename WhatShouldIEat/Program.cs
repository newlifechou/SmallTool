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
            WhatToEat wte = new WhatToEat
            {
                Foods = new FoodDataFactory().GetFoods()
            };

            for (int i = 0; i < 15; i++)
            {
                var food = wte.GetFood();
                Console.WriteLine($"{i.ToString().PadRight(3)}  {food.Name.PadRight(10)} {food.Price:C}");
            }

            Console.Read();
        }
    }
}
