using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace LoveDouban
{
    class DoubanOperation
    {
        public static void GetJson()
        {
            string url = @"https://api.douban.com/v2/book/1220562";
            var request = WebRequest.CreateHttp(url);
            var response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string json_data = sr.ReadToEnd();
            //Console.WriteLine(json_data);

            var model = JsonConvert.DeserializeObject<BookModel>(json_data);

            Console.WriteLine(model.title);
            Console.WriteLine(model.binding);
            Console.WriteLine(model.id);
            Console.WriteLine(model.alt);
            Console.WriteLine(model.rating.average);
            Console.WriteLine(model.author[0]);
            Console.WriteLine(model.summary);
            Console.WriteLine(model.author_intro);


            foreach (var item in model.tags)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.title);
                Console.WriteLine(item.count);
            }

            Console.WriteLine(model.price);

        }
    }
}
