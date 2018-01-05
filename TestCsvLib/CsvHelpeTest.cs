using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
namespace TestCsvLib
{

    public class CsvHelperTest
    {
        private string dataForRead;
        private string dataForWrite;
        public CsvHelperTest()
        {
            dataForRead = Path.Combine(Environment.CurrentDirectory, "dataForRead.csv");
            dataForWrite = Path.Combine(Environment.CurrentDirectory, "dataForWrite.csv");
        }
        public void TestWriteRecord()
        {
            var persons = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                persons.Add(new Person { Name = "peter" + i, Age = 22 + i, Language = "C#" + i });
            }
            FileStream fs = new FileStream(dataForWrite, FileMode.Append);
            var csv = new CsvWriter(new StreamWriter(fs));
            csv.WriteRecords(persons);
            Console.WriteLine("写入完毕");
            fs.Flush();
        }
        public void TestReadRecord()
        {
            var csv = new CsvReader(new StreamReader(dataForRead));
            //var persons = csv.GetRecords<Person>();
            //var persons = csv.GetRecords(typeof(Person));
            //foreach (var pp in persons)
            //{
            //    var p = pp as Person;
            //    Console.WriteLine($"{p.Name}-{p.Age}-{p.Language}");
            //}

            //var persons = csv.GetRecords<dynamic>();
            //foreach (var p in persons)
            //{
            //    Console.WriteLine(p.Name);
            //}

            //var anoy = new { Name = "", Age = 0, Language = "" };
            //var persons = csv.GetRecords(anoy);
            //foreach (var p in persons)
            //{
            //    Console.WriteLine(p.Name);
            //}

            var p = new Person();
            var persons = csv.EnumerateRecords<Person>(p);
            //foreach (var item in persons)
            //{
            //    Console.WriteLine(item.Name);
            //}
            csv.Read();
            //csv.ReadHeader();
            //while (csv.Read())
            //{
            //    var record = csv.GetRecord<Person>();
            //    Console.WriteLine(record.Name);
            //}
            //var record = csv.GetRecord<Person>();
            //Console.WriteLine(record.Name);
            csv.Read();
            var field = csv[2];
            Console.WriteLine(field);

        }
    }
}
