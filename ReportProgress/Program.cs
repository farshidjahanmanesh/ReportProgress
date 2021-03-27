using System;

namespace ReportProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            Report rep = new Report();
            rep.DoTask().Wait();
            Console.WriteLine("end");
        }
    }
}
