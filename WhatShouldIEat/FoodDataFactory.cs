using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatShouldIEat
{
    class FoodDataFactory
    {
        public List<Food> GeneratorAllFood()
        {
            List<Food> foods = new List<Food>();
            foods.Add(new Food { Name="酸菜鱼米线",Price=14,})


            return foods;
        }
    }
}
