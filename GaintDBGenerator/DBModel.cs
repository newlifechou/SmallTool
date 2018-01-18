using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaintDBGenerator
{
    /// <summary>
    /// 测试模型
    /// </summary>
    class DBModel
    {
        public Guid ID { get; set; }
        public int Field1 { get; set; }
        public double Field2 { get; set; }
        public DateTime CreateTime { get; set; }
        public string ThreadID { get; set; }
    }
}
