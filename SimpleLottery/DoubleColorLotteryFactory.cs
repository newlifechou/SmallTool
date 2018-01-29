using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery
{
    class DoubleColorLotteryFactory
    {

        private Random rand;
        public DoubleColorLotteryFactory()
        {
            rand = new Random();
        }

        public List<DoubleColorLottery> CreateLotteries(int count)
        {
            List<DoubleColorLottery> lotteries = new List<DoubleColorLottery>();


            return lotteries;
        }

        private DoubleColorLottery GetSingleLottery()
        {

            DoubleColorLottery lottery = new DoubleColorLottery
            {
                GenerateTime = DateTime.Now,
                Red = GetReds(),
                Blue = GetLotteryNumber(16)
            };

            return lottery;
        }

        private int[] GetReds()
        {
            int[] reds = new int[6];
            int number = GetLotteryNumber(33);
            
            return reds;
        }

        private int GetLotteryNumber(int max)
        {
            return rand.Next(1, max);
        }

    }
}
