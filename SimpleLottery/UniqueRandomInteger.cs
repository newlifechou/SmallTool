using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery
{
    /// <summary>
    /// 一个可以产生不重复随机数的类
    /// </summary>
    public class UniqueRandomInteger
    {
        private Random rand;
        public UniqueRandomInteger()
        {
            rand = new Random();
        }

        /// <summary>
        /// 得到不完全范围的随机数组
        /// </summary>
        /// <param name="count"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int[] GetPartRandomArray(int count, int min, int max)
        {
            int[] data = new int[count];
            int[] pos = new int[count];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
                pos[i] = 0;
            }



            return data;
        }


        /// <summary>
        /// 得到完全范围的随机数组
        /// </summary>
        public int[] GetFullRandomArray(int count, int min)
        {
            int[] data = new int[count];
            for (int i = 0; i < count; i++)
                data[i] = i + min;

            for (int i = 0; i < count; i++)
            {
                int shuffleIndex = rand.Next(0, count);
                int tmp = data[shuffleIndex];
                data[shuffleIndex] = data[i];
                data[i] = tmp;
            }
            return data;
        }

    }


}
