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
        private string jsonFile;
        [TestInitialize]
        public void FirstRun()
        {
            jsonFile = Path.Combine(Directory.GetCurrentDirectory(), "foods.json");
        }

        [TestMethod()]
        public void GetAllFoodsTest()
        {
            WhatToEat wte = new WhatToEat
            {
                JsonFile = jsonFile
            };
            var results = wte.GetAllFoods();
            Assert.IsTrue(results.Count >= 0);
        }

        [TestMethod()]
        public void GetSingleRandomFoodTest()
        {
            WhatToEat wte = new WhatToEat
            {
                JsonFile = jsonFile
            };

            var result = wte.GetSingleRandomFood();

            Assert.IsNotNull(result);
        }
    }
}