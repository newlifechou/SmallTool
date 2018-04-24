using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shibor
{
    public class ShiborModel
    {
        public ShiborModel()
        {
            Name = "";
            Shibor = BP = 0;
        }
        public string Name { get; set; }
        public double Shibor { get; set; }
        public double BP { get; set; }

    }
}
