using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;

namespace GaintDBGenerator
{
    class Mass
    {
        private string sqlconstr;
        private Random rand;
        private CancellationTokenSource cancelSource;
        private int threadCount;
        public Mass()
        {
            rand = new Random();
            sqlconstr = ConfigurationManager.ConnectionStrings["servertwo"].ConnectionString;
            cancelSource = new CancellationTokenSource();
            threadCount = 3;
        }

        public CancellationTokenSource CancelSource
        {
            get
            {
                return cancelSource;
            }
        }

        public void TaskWriteData()
        {
            Console.WriteLine("开始创建所有线程");
            for (int i = 0; i < threadCount; i++)
            {
                Task t = new Task(() =>
                  {
                      WriteSingle(cancelSource.Token, i + 1);
                  }, cancelSource.Token);
                t.Start();
                Console.WriteLine($"第{i + 1}个线程开始写入数据库");
            }
            Console.WriteLine("结束创建所有线程");

        }

        private void TaskExceptionHandle(Task task)
        {
            foreach (var item in task.Exception.InnerExceptions)
            {
                Console.WriteLine($"{item.Message}");
            }
        }


        private async void WriteSingle(CancellationToken token, int threadNumber)
        {
            //每个Thread拥有自己的con和cmd
            SqlConnection con = new SqlConnection(sqlconstr);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into dbmodel (id,field1,field2,createtime,threadid) values(@id,@field1,@field2,@createtime,@threadid)";
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                while (!token.IsCancellationRequested)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@field1", rand.Next());
                    cmd.Parameters.AddWithValue("@field2", rand.NextDouble());
                    cmd.Parameters.AddWithValue("@createtime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@threadid", Thread.CurrentThread.ManagedThreadId.ToString());
                    int result = await cmd.ExecuteNonQueryAsync(cancelSource.Token);
                    Debug.Write("*");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"取消任务{threadNumber}");
                con.Close();
            }

        }


    }
}
