using System;
using System.Diagnostics;

namespace Netizen.ID.Demo;

class Program
{
    static void Main(string[] args)
    {
        var makeInt64SingleElapsed = MakeInt64BySingle();
        var makeInt64ManyElapsed = MakeInt64ByMany();
        var makeChar24SingleElapsed = MakeChar24BySingle();
        var makeChar24ManyElapsed = MakeChar24ByMany();
        Console.WriteLine($"int64 => single: {makeInt64SingleElapsed} many: {makeInt64ManyElapsed}");
        Console.WriteLine($"char24 => single: {makeChar24SingleElapsed} many: {makeChar24ManyElapsed}");
        Console.ReadLine();
    }

    private static TimeSpan MakeInt64BySingle(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Int64IDMaker idmkr = new Int64IDMaker();
        long[] ids = new long[count];
        sw.Restart();
        for (int i = 0; i < count; ++i)
        {
            ids[i] = idmkr.Make();
        }
        sw.Stop();
        foreach (long id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeInt64ByMany(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Int64IDMaker idmkr = new Int64IDMaker();
        sw.Restart();
        long[] ids = idmkr.MakeMany(count);
        sw.Stop();
        foreach (long id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeChar24BySingle(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Char24IDMaker idmkr = new Char24IDMaker("netz");
        sw.Restart();
        string[] ids = new string[count];
        for(int i = 0; i < count; i++)
        {
            ids[i] = idmkr.Make();
        }
        sw.Stop();
        foreach (string id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeChar24ByMany(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Char24IDMaker idmkr = new Char24IDMaker("netz");
        sw.Restart();
        string[] ids = idmkr.MakeMany(count);
        sw.Stop();
        foreach (string id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }
}
