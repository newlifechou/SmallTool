using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WhatShouldIEat
{
    /// <summary>
    /// 吃什么类
    /// 这个类用来提供按条件选择食物的功能
    /// 并提供自定义需求
    /// </summary>
    public class WhatToEat
    {
        public WhatToEat()
        {
            rand = new Random();
            Foods = new List<Food>();
            FoodCategories = new List<FoodCategory>();
            FoodCharacteristics = new List<FoodCharacteristic>();
        }

        public List<Food> Foods { get; set; }
        public List<FoodCategory> FoodCategories { get; set; }
        public List<FoodCharacteristic> FoodCharacteristics { get; set; }

        private Random rand;

        public Food GetFood()
        {
            if (Foods.Count == 0)
            {
                throw new ApplicationException("Foods集合为空");
            }
            return Foods[rand.Next(0, Foods.Count - 1)];
        }

        public Food GetFood(string category, string character)
        {

            return null;
        }


    }
}
