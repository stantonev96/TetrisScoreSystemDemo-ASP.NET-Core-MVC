using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            double score = 999.980;

            Console.WriteLine(string.Format("{0:0.000}", score));
        }
    }
}
