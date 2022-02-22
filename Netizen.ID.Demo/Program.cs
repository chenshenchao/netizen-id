using System;

namespace Netizen.ID.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IdentifierMaker idmkr = new IdentifierMaker();
            long[] ids1 = new long[1000];
            for (int i = 0; i <= 1000; ++i)
            {
                ids1[i] = idmkr.Make();
            }
            foreach(long id1 in ids1)
            {
                Console.WriteLine(id1);
            }

            long[] ids2 = idmkr.MakeMany(1000);
            foreach (long id2 in ids2)
            {
                Console.WriteLine(id2);
            }
            Console.ReadLine();
        }
    }
}
