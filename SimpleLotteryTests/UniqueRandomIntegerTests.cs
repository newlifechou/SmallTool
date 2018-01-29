using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLottery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery.Tests
{
    [TestClass()]
    public class UniqueRandomIntegerTests
    {
        [TestMethod()]
        public void ShuffleTest()
        {
            int[] testData = { 1, 2, 3, 4, 5 };
            int[] resultData = new UniqueRandomInteger().GetFullRandomArray(5, min: 1);
            bool result = false;
            for (int i = 0; i < resultData.Length; i++)
            {
                if (testData[i] != resultData[i])
                {
                    //只要有一个位置不一样即可
                    result = true;
                    break;
                }
            }
            Assert.IsTrue(result);
        }
    }
}