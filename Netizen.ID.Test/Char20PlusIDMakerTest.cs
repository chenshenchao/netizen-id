using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Netizen.ID.Test;

[TestClass]
public class Char20PlusIDMakerTest
{
    private Char20PlusIDMaker char20PlusIDMaker;

    public Char20PlusIDMakerTest()
    {
        char20PlusIDMaker = new Char20PlusIDMaker("netz");
    }

    [TestMethod]
    public void TestMake()
    {
        const int size = 1024;
        string[] results = new string[size];
        for (int i = 0; i < size; i++)
        {
            results[i] = char20PlusIDMaker.Make();
        }
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());
    }

    [TestMethod]
    public void TestMakeMany()
    {
        const int size = 1024;
        string[] results = char20PlusIDMaker.MakeMany(size);
        var r = results.Distinct();
        Assert.AreEqual(size, r.Count());
    }
}
