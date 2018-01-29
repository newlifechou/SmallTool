using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery
{
    /// <summary>
    /// 不重复随机数类
    /// </summary>
    public class UnrepeatRandomNumber
    {
        private Random rand;
        public UnrepeatRandomNumber()
        {
            rand = new Random();
        }

        /// <summary>
        /// 全序列随机
        /// </summary>
        /// <param name="count"></param>
        /// <param name="suffleTime"></param>
        /// <returns></returns>
        public int[] GetFullRandomArray(int count, int suffleTime = 10)
        {
            int[] data = new int[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = i + 1;
            }

            if (suffleTime > count)
            {
                suffleTime = count;
            }

            Suffle(data, 20);

            return data;
        }

        private void Suffle(int[] data, int suffleTime)
        {
            int dataLength = data.Length;
            //洗count次牌
            for (int i = 0; i < suffleTime; i++)
            {
                int placeIndex1 = rand.Next(0, dataLength);
                int placeIndex2 = rand.Next(0, dataLength);
                if (placeIndex1 == placeIndex2)
                    continue;
                Swap(ref data[placeIndex1], ref data[placeIndex2]);
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

    }
}
