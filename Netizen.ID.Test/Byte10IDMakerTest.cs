using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Netizen.ID.Test;

[TestClass]
public class Byte10IDMakerTest
{
    private Byte10IDMaker maker;

    public Byte10IDMakerTest()
    {
        maker = new Byte10IDMaker(1);
    }

    [TestMethod]
    public void TestMake()
    {
        const int size = 1024;
        byte[][] results = new byte[size][];
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
        byte[][] results = maker.MakeMany(size);
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());
    }
}
