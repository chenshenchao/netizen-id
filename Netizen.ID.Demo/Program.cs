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
        var makeCharset32SingleElapsed = MakeCharset32IDBySingle();
        var makeCharset32ManyElapsed = MakeCharset32IDByMany();
        Console.WriteLine($"int64 => single: {makeInt64SingleElapsed} many: {makeInt64ManyElapsed}");
        Console.WriteLine($"char20Plus => single: {makeChar20PlusSingleElapsed} many: {makeChar20PlusManyElapsed}");
        Console.WriteLine($"byte10 => single: {makeByte10SingleElapsed} many: {makeByte10ManyElapsed}");
        Console.WriteLine($"charset32 => single: {makeCharset32SingleElapsed} many: {makeCharset32ManyElapsed}");
        Console.ReadLine();
    }

    private static TimeSpan MakeInt64BySingle(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        Int64IDMaker maker = new Int64IDMaker();
        long[] ids = new long[count];
        sw.Restart();
        for (int i = 0; i < count; ++i)
        {
            ids[i] = maker.Make();
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
        Int64IDMaker maker = new Int64IDMaker();
        sw.Restart();
        long[] ids = maker.MakeMany(count);
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
        Char20PlusIDMaker maker = new Char20PlusIDMaker("netz");
        sw.Restart();
        string[] ids = new string[count];
        for(int i = 0; i < count; i++)
        {
            ids[i] = maker.Make();
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
        Char20PlusIDMaker maker = new Char20PlusIDMaker("netz");
        sw.Restart();
        string[] ids = maker.MakeMany(count);
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
        var maker = new Byte10IDMaker(1);
        sw.Restart();
        byte[][] ids = new byte[count][];
        for (int i = 0;i < count; i++)
        {
            ids[i] = maker.Make();
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
        var maker = new Byte10IDMaker(1);
        sw.Restart();
        byte[][] ids = maker.MakeMany(count);
        sw.Stop();
        foreach (byte[] id in ids)
        {
            Console.WriteLine(Convert.ToHexString(id));
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeCharset32IDBySingle(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var maker = new Charset32IDMaker(1);
        sw.Restart();
        string[] ids = new string[count];
        for(int i = 0;i < count; i++)
        {
            ids[i] = maker.Make();
        }
        sw.Stop();
        foreach(string id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }

    private static TimeSpan MakeCharset32IDByMany(int count=1024)
    {
        Stopwatch sw = Stopwatch.StartNew();
        var maker = new Charset32IDMaker(1);
        sw.Restart();
        string[] ids = maker.MakeMany(count);
        sw.Stop();
        foreach (string id in ids)
        {
            Console.WriteLine(id);
        }
        return sw.Elapsed;
    }
}
