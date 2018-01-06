using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCsvLib
{
    public class PersonMap:ClassMap<Person>
    {
        public PersonMap()
        {
            Map(m => m.Name).Name("名称");
            Map(m => m.Age).Name("年龄");
            Map(m => m.Language).Name("语言");
        }
    }
}
