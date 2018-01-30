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


        /// <summary>
        /// 从更大的范围选择一部分不重复的随机数
        /// </summary>
        /// <param name="count"></param>
        /// <param name="countReady"></param>
        /// <returns></returns>
        public int[] GetPartRandomArray(int countWant, int countReady)
        {
            int[] data = new int[countWant];
            int[] position = new int[countReady];
            for (int i = 0; i < countReady; i++)
            {
                position[i] = i;
            }

            for (int i = 0; i < countWant; i++)
            {
                int randPosition = 0;
                do
                {
                    randPosition = rand.Next(0, countReady);
                } while (position[randPosition] == -1);
                data[i] = randPosition;
                position[randPosition] = -1;
            }
            return data;
        }
    }
}
