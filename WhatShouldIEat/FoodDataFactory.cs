using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatShouldIEat
{
    class FoodDataFactory
    {
        public List<FoodCategory> GetFoodCategories()
        {
            List<FoodCategory> categories = new List<FoodCategory>
            {
                new FoodCategory{Id=1,CategoryName="面食"},
                new FoodCategory{Id=2,CategoryName="米"},
                new FoodCategory{Id=3,CategoryName="其他"}
            };
            return categories;
        }
        public List<FoodCharacteristic> GetFoodCharacteristics()
        {
            List<FoodCharacteristic> characteristics = new List<FoodCharacteristic>()
            {
                new FoodCharacteristic{Id=1,CharacteristicName="辣" },
                new FoodCharacteristic{Id=2,CharacteristicName="酸" },
                new FoodCharacteristic{Id=3,CharacteristicName="麻" },
                new FoodCharacteristic{Id=4,CharacteristicName="鲜" },
                new FoodCharacteristic{Id=5,CharacteristicName="甜" }
            };
            return characteristics;
        }
        public List<Food> GetFoods()
        {
            List<Food> foods = new List<Food>
            {
                new Food {Id=1, Name = "酸菜鱼米线", Price = 14,FoodCategoryId=2,CharacteristicId=2 },
                new Food {Id=2, Name = "豆腐鱼米线", Price = 14,FoodCategoryId=2,CharacteristicId=1 },
                new Food {Id=3, Name = "3两燃面+鸡蛋", Price = 14,FoodCategoryId=1,CharacteristicId=1 },
                new Food {Id=4, Name = "虾饺冒菜+米饭", Price = 22,FoodCategoryId=2,CharacteristicId=4 },
                new Food {Id=5, Name = "酸辣粉+锅魁", Price = 20,FoodCategoryId=2,CharacteristicId=2 },
                new Food {Id=6, Name = "肥肠粉+锅魁", Price = 20,FoodCategoryId=2,CharacteristicId=1 },
                new Food {Id=7, Name = "饺子", Price = 18,FoodCategoryId=1,CharacteristicId=4 },
                new Food {Id=8, Name = "翘脚牛肉+米饭", Price = 22,FoodCategoryId=2,CharacteristicId=1 },
            };


            return foods;
        }
    }
}
