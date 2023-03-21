

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Netizen.ID.Test;

[TestClass]
public class Charset32IDMakerTest
{
    private Charset32IDMaker maker;

    public Charset32IDMakerTest()
    {
        maker = new Charset32IDMaker(1);
    }

    [TestMethod]
    public void TestMake()
    {
        const int size = 1024;
        string[] results = new string[size];
        for(int i = 0; i < size; i++)
        {
            results[i] = maker.Make();
        }
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());
    }

    [TestMethod]
    public void TestMakeMany()
    {
        const int size = 1024;
        string[] results = maker.MakeMany(size);
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());

    }
}
