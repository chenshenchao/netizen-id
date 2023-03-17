using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Netizen.ID.Test;

[TestClass]
public class Int64IDMakerTest
{
    private Int64IDMaker identifierMaker;

    public Int64IDMakerTest()
    {
        identifierMaker = new Int64IDMaker();
    }

    [TestMethod]
    public void TestMake()
    {
        const int size = 1000;
        long[] results = new long[size];
        for (int i = 0; i < size; ++i)
        {
            results[i] = identifierMaker.Make();
        }
        var r = results.GroupBy(i => i);
        Assert.AreEqual(size, r.Count());
    }

    [TestMethod]
    public void TestMakeMany()
    {
        const int size = 1000;
        long[] results = identifierMaker.MakeMany(size);
        var r = results.GroupBy(i => i);
        Assert.AreEqual(size, r.Count());
    }
}