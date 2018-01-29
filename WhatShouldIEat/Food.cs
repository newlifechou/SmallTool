using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatShouldIEat
{
    /// <summary>
    /// 食物类
    /// </summary>
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int FoodCategoryId { get; set; }
        public int CharacteristicId { get; set; }
    }
}
