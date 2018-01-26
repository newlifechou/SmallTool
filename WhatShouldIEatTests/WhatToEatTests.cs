using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatShouldIEat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WhatShouldIEat.Tests
{
    [TestClass()]
    public class WhatToEatTests
    {
        [TestMethod()]
        public void GetAllFoodsTest()
        {
            string jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "foods.json");
            WhatToEat wte = new WhatToEat
            {
                JsonFile = jsonFile
            };
            var results = wte.GetAllFoods();
            Assert.IsTrue(results.Count >= 0);
        }


    }
}