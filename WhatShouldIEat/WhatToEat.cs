using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatShouldIEat
{
    /// <summary>
    /// 吃什么类
    /// 这个类用来提供按条件选择食物的功能
    /// 并提供自定义需求
    /// </summary>
    class WhatToEat
    {
        private List<Food> foods;
        public WhatToEat()
        {
            foods = new List<Food>();
        }


        public int AddFood(Food food)
        {
            throw new NotImplementedException();
        }

        public int UpdateFood(Food food)
        {
            throw new NotImplementedException();
        }

        public int DeleteFood(int id)
        {
            throw new NotImplementedException();
        }


    }
}
