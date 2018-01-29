using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery
{
    public class DoubleColorLottery
    {
        public DoubleColorLottery()
        {
            ID = Guid.NewGuid();
            GenerateTime = DateTime.Now;
            Red = new int[6];
            Blue = 0;
        }
        public Guid ID { get; set; }
        public DateTime GenerateTime { get; set; }

        public int[] Red { get; set; }

        public int Blue { get; set; }
    }
}
