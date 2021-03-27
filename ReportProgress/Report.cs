using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReportProgress
{
    public class Report
    {
        public async Task DoTask()
        {
            Console.WriteLine("base thread is :"+Thread.CurrentThread.ManagedThreadId);
            Action<int> progress = i => {
                Console.WriteLine("action thread id is :"+Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(i);
            };
            await ReportSomeWork(progress);
        }
        private Task ReportSomeWork(Action<int> onProgressPercentChanged)
        {
            return Task.Run(() =>
            {
                for(int i = 0; i < 1000; i++)
                {
                    if (i % 10 == 0)
                        onProgressPercentChanged(i / 10);
                    Console.WriteLine("report thread id:"+Thread.CurrentThread.ManagedThreadId);
                    
                    //some code
                }
            });
        }
    }
}
