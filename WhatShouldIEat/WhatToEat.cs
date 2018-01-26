using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace WhatShouldIEat
{
    /// <summary>
    /// 吃什么类
    /// 这个类用来提供按条件选择食物的功能
    /// 并提供自定义需求
    /// </summary>
    public class WhatToEat
    {
        private List<Food> foods;
        private string jsonFile;
        public WhatToEat()
        {
            jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "foods.json");
            LoadFoodsFromJsonFile();
        }

        /// <summary>
        /// 类外设置JsonFile路径
        /// </summary>
        public string JsonFile
        {
            set
            {
                jsonFile = value;
            }
        }


        #region 获取
        private void LoadFoodsFromJsonFile()
        {
            string jsonContent = File.ReadAllText(jsonFile);
            foods = JsonConvert.DeserializeObject<List<Food>>(jsonContent);
        }

        public List<Food> GetAllFoods()
        {
            LoadFoodsFromJsonFile();
            return foods;
        }

        public Food GetSingleRandomFood(string character, double priceLessThan)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 操作List<Food>
        public void AddFood(Food food)
        {
            if (foods != null)
            {
                foods.Add(food);
            }
        }

        public void UpdateFood(Food food)
        {
            if (foods == null) return;
            var currentFood = foods.Find(f => f.Name == food.Name);
            currentFood.Price = food.Price;
            currentFood.Characteristic = food.Characteristic;
        }

        public void DeleteFood(string foodName)
        {
            if (foods == null) return;
            var food = foods.Find(f => f.Name == foodName);
            foods.Remove(food);
        }

        public void SaveFoodList()
        {
            string jsonContent = JsonConvert.SerializeObject(foods);
            File.WriteAllText(jsonFile, jsonContent);
        }

        #endregion
    }
}
