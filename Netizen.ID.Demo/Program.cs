using System;

namespace Netizen.ID.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IdentifierMaker idmkr = new IdentifierMaker(0);
            for (int i = 0; i <= 1000; ++i)
            {
                Console.WriteLine(idmkr.Make());
            }
            Console.ReadLine();
        }
    }
}
