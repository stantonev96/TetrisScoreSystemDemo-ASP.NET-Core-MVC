using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            double score = 999.980;

            Console.WriteLine(string.Format("{0:0.000}", score));

            DateTime test = DateTime.Now;
            Console.WriteLine(test.ToString("HH:mm"));
        }
    }
}
