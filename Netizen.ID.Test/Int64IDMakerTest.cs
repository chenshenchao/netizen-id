using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Netizen.ID.Test;

[TestClass]
public class Int64IDMakerTest
{
    private Int64IDMaker int64IDMaker;

    public Int64IDMakerTest()
    {
        int64IDMaker = new Int64IDMaker();
    }

    [TestMethod]
    public void TestMake()
    {
        const int size = 1024;
        long[] results = new long[size];
        for (int i = 0; i < size; ++i)
        {
            results[i] = int64IDMaker.Make();
        }
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());
    }

    [TestMethod]
    public void TestMakeMany()
    {
        const int size = 1024;
        long[] results = int64IDMaker.MakeMany(size);
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());
    }
}