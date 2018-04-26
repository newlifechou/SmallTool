using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;

namespace Shibor
{
    public class ShiborLib
    {
        /// <summary>
        /// 分析Shibor.Org
        /// 其页面比较老，是2006的，使用了大量的iFrame和Table嵌套
        /// 因为我只需要每日的Shibor数据
        /// 所以只需要其中的一个iFrame里的页面链接即可
        /// </summary>
        private string url = @"http://www.shibor.org//shibor/Shibor.do?date=";
        private string excel = Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

        public void ShowShibor()
        {
            var shibors = Download(DateTime.Now);
            shibors.ForEach(shibor => Console.WriteLine($"{shibor.Name} {shibor.Shibor} {shibor.BP}"));
            Console.WriteLine("任务完成");
        }
        public List<ShiborModel> Download(DateTime shiborDate)
        {
            string new_url = $"{url}{shiborDate.ToString("yyyy-MM-dd")}";
            List<ShiborModel> shibors = new List<ShiborModel>();
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(new_url);
                var results = doc.DocumentNode.SelectSingleNode("//table[@class='shiborquxian']");
                foreach (var item in results.Descendants("tr"))
                {
                    var tds = item.Descendants("td").ToList();
                    var name = tds[1].InnerText;
                    var shibor = tds[2].InnerText;
                    var bp = tds[4].InnerText;
                    shibors.Add(new ShiborModel
                    {
                        Name = name,
                        Shibor = double.Parse(shibor),
                        BP = double.Parse(bp)
                    });

                }
            }
            catch (Exception)
            {
                Console.WriteLine($"处理{shiborDate.ToString("yyyyMMdd")}");
            }

            return shibors;
        }
        public void DownloadTask()
        {
            BatchDownLoad(new DateTime(2016, 1, 1), new DateTime(2018, 4, 25));
            Console.WriteLine("Shibor任务结束");
        }

        public void BatchDownLoad(DateTime startDate, DateTime endDate)
        {
            try
            {
                XSSFWorkbook workbook2007 = new XSSFWorkbook();
                workbook2007.CreateSheet("Shibor");
                if (File.Exists(excel))
                {
                    File.Delete(excel);
                }
                FileStream fs = new FileStream(excel, FileMode.CreateNew);
                XSSFSheet sheet = (XSSFSheet)workbook2007.GetSheet("Shibor");
                XSSFRow first_row = (XSSFRow)sheet.CreateRow(0);
                ((XSSFCell)first_row.CreateCell(0)).SetCellValue("日期");
                ((XSSFCell)first_row.CreateCell(1)).SetCellValue("O/N");
                ((XSSFCell)first_row.CreateCell(2)).SetCellValue("1W");
                ((XSSFCell)first_row.CreateCell(3)).SetCellValue("2W");
                ((XSSFCell)first_row.CreateCell(4)).SetCellValue("1M");
                ((XSSFCell)first_row.CreateCell(5)).SetCellValue("3M");
                ((XSSFCell)first_row.CreateCell(6)).SetCellValue("6M");
                ((XSSFCell)first_row.CreateCell(7)).SetCellValue("9M");
                ((XSSFCell)first_row.CreateCell(8)).SetCellValue("1Y");

                var dataformat = workbook2007.CreateDataFormat();
                var style = workbook2007.CreateCellStyle();
                style.DataFormat = dataformat.GetFormat("yyyy-MM-dd");

                int rowNumber = 1;
                DateTime currentDate = startDate;
                while (currentDate < endDate)
                {
                    var shibors = Download(currentDate);
                    if (shibors.Count == 0)
                        continue;

                    XSSFRow temp_row = (XSSFRow)sheet.CreateRow(rowNumber);
                    ((XSSFCell)temp_row.CreateCell(0)).SetCellValue(currentDate.Date);
                    temp_row.GetCell(0).CellStyle = style;

                    ((XSSFCell)temp_row.CreateCell(1)).SetCellValue(shibors[0].Shibor);
                    ((XSSFCell)temp_row.CreateCell(2)).SetCellValue(shibors[1].Shibor);
                    ((XSSFCell)temp_row.CreateCell(3)).SetCellValue(shibors[2].Shibor);
                    ((XSSFCell)temp_row.CreateCell(4)).SetCellValue(shibors[3].Shibor);
                    ((XSSFCell)temp_row.CreateCell(5)).SetCellValue(shibors[4].Shibor);
                    ((XSSFCell)temp_row.CreateCell(6)).SetCellValue(shibors[5].Shibor);
                    ((XSSFCell)temp_row.CreateCell(7)).SetCellValue(shibors[6].Shibor);
                    ((XSSFCell)temp_row.CreateCell(8)).SetCellValue(shibors[7].Shibor);

                    Console.WriteLine($"{currentDate.Date}处理OK");
                    currentDate = currentDate.AddDays(1);
                    rowNumber++;
                }

                workbook2007.Write(fs);
                fs.Close();
                workbook2007.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

