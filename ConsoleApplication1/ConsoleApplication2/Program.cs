using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Action();
            t.Wait();
            Console.ReadLine(); // чтобы без брекпоинта было
        }

        public static void Action()
        {
            var wc = new WebClient();
            wc.DownloadStringTaskAsync("http://vk.com")
                .ContinueWith(c => Console.WriteLine(c.Result));

        }

        //public static async Task Action2()
        //{
        //    var wc = new WebClient();
        //    var v = await wc.DownloadStringTaskAsync("http://vk.com");
        //    using (var file = File.Open(@"D:\tempfile.txt", FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        using (var sw = new StreamWriter(file))
        //        {
        //            await sw.WriteAsync(v);
        //        }
        //    }
        //}

        public static void Action2()
        {
            var wc = new WebClient();
            wc.DownloadStringTaskAsync("http://vk.com").ContinueWith(c =>
            {
                var file = File.Open(@"D:\tempfile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                var sw = new StreamWriter(file);
                sw.WriteAsync(c.Result).ContinueWith(r =>
                {
                    file.Dispose();
                    sw.Dispose();
                });
            });
        }

        public static async Task ActionWithContent()
        {
            var content = await GetContent();
            Console.WriteLine(content);
        }

        public static async Task<string> GetContent()
        {
            var wc = new WebClient();
            return await wc.DownloadStringTaskAsync("http://vk.com");
        }

        public static async Task<double> LongTask()
        {
            Console.WriteLine("Thread starting sleeping");
            // Thread.Sleep(5000); dont use thread.sleep!
            //await Task.Delay(5000); - good!
            double result = 50;
            for (int i = 0; i < 99999999; i++)
            {
                result += Math.Sqrt(i);
            }
            Console.WriteLine("Thread stopped sleeping: {0}", result);

            return await Task.FromResult(result);
        }
    }
}
