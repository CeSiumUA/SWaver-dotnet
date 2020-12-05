using SWaverLib;
using System;

namespace SWAverCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FiderCalculation.FiderExtinction(2, 0.01));
            Console.ReadLine();
        }
    }
}
