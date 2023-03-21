using System.Linq;

namespace Netizen.ID;

public class Charset32IDMaker
{
    public const string Charset = "23456789abcdefghjklmnpqrstuvwxyz";

    private Byte10IDMaker maker;

    public Charset32IDMaker(short makerId)
    {
        maker = new Byte10IDMaker(makerId);
    }

    private string Convert(byte[] bytes)
    {
        var result = new char[16];
        for (int i = 0; i < result.Length; ++i)
        {
            int s = i * 5;
            int si = s >> 3; // s / 8; // 算出所在字节
            int srs = s & 0b111; // s % 8; // 算出右移位
            int sv = (bytes[si] >> srs) & 0b11111;

            int e = s + 5;
            int ei = e >> 3; // e / 8; // 算出所在字节
            if (ei > si && e < 80)
            {
                int els = 5 - (e & 0b111); // 5 - (e % 8); // 算出左移位
                int ev = (bytes[ei] << els) & 0b11111;
                sv = sv | ev;
            }
            result[i] = Charset[sv];
        }
        return new string(result);
    }

    public string Make()
    {
        return Convert(maker.Make());
    }

    public string[] MakeMany(long count)
    {
        return maker.MakeMany(count)
            .Select(b => Convert(b))
            .ToArray();
    }
}
