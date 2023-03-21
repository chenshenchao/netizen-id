using System;
using System.Diagnostics;

namespace Netizen.ID.Demo;

class Program
{
    static void Main(string[] args)
    {
        var makeInt64SingleElapsed = MakeInt64BySingle();
        var makeInt64ManyElapsed = MakeInt64ByMany();
        var makeChar20PlusSingleElapsed = MakeChar20PlusBySingle();
        var makeChar20PlusManyElapsed = MakeChar20PlusByMany();
        var makeByte10SingleElapsed = MakeByte10IDBySingle();
        var makeByte10ManyElapsed = MakeByte10IDByMany();
        Console.WriteLine($"int64 => single: {makeInt64SingleElapsed} many: {makeInt64ManyElapsed}");
        Console.WriteLine($"char20Plus => single: {makeChar20PlusSingleElapsed} many: {makeChar20PlusManyElapsed}");
        Console.WriteLine($"byte10 => single: {makeByte10SingleElapsed} may: {makeByte10ManyElapsed}");
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

    private static TimeSpan MakeChar20PlusBySingle(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Char20PlusIDMaker idmkr = new Char20PlusIDMaker("netz");
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

    private static TimeSpan MakeChar20PlusByMany(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Char20PlusIDMaker idmkr = new Char20PlusIDMaker("netz");
        sw.Restart();
        string[] ids = idmkr.MakeMany(count);
        sw.Stop();
        foreach (string id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeByte10IDBySingle(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var idmkr = new Byte10IDMaker(1);
        sw.Restart();
        byte[][] ids = new byte[count][];
        for (int i = 0;i < count; i++)
        {
            ids[i] = idmkr.Make();
        }
        sw.Stop();
        foreach(byte[] id in ids)
        {
            Console.WriteLine(Convert.ToHexString(id));
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeByte10IDByMany(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var idmkr = new Byte10IDMaker(1);
        sw.Restart();
        byte[][] ids = idmkr.MakeMany(count);
        sw.Stop();
        foreach (byte[] id in ids)
        {
            Console.WriteLine(Convert.ToHexString(id));
        }
        return sw.Elapsed;
    }
}
