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
        private string dataForRead2;
        private string dataForWrite;
        public CsvHelperTest()
        {
            dataForRead = Path.Combine(Environment.CurrentDirectory, "dataForRead.csv");
            dataForRead2 = Path.Combine(Environment.CurrentDirectory, "dataForRead2.csv");
            dataForWrite = Path.Combine(Environment.CurrentDirectory, "dataForWrite.csv");
        }
        public void TestWriteWithMapping()
        {

            var sr = new StreamReader(dataForRead2);
            var csv = new CsvReader(sr);
            csv.Configuration.RegisterClassMap<PersonMap>();
            csv.Configuration.HeaderValidated = null;
            var result = csv.GetRecords<Person>();
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Age);
                Console.WriteLine(item.Language);
            }



            csv.Dispose();
        }

        public void TestWriteRecord()
        {
            var persons = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                persons.Add(new Person { Name = "peter" + i, Age = 22 + i, Language = "C#" + i });
            }
            if (File.Exists(dataForWrite)) File.Delete(dataForWrite);
            FileStream fs = new FileStream(dataForWrite, FileMode.CreateNew);
            var csv = new CsvWriter(new StreamWriter(fs));
            csv.WriteRecords(persons);
            Console.WriteLine("写入完毕");
            csv.Dispose();

            //Person p = new Person { Name = "jack", Age = 22, Language = "TypeScript" };
            //if (File.Exists(dataForWrite))
            //{
            //    File.Delete(dataForWrite);
            //}
            //FileStream fs = new FileStream(dataForWrite, FileMode.CreateNew);
            //var csv = new CsvWriter(new StreamWriter(fs));
            //csv.WriteHeader(typeof(Person));
            //csv.NextRecord();
            //csv.WriteRecord<Person>(p);
            //csv.NextRecord();
            //csv.Dispose();
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
