
using System;

namespace Netizen.ID;

public class Char20PlusIDMaker
{
    public const long IdMax = 999;

    public string MakerId { get; init; }
    public long LastId { get; private set; }
    public DateTime LastAt { get; private set; }

    public Char20PlusIDMaker(string makerId)
    {
        MakerId = makerId;
        LastId = 1;
        LastAt = DateTime.Now;
    }

    public string Make()
    {
        var now = DateTime.Now;
        long diff = (LastAt - now).Ticks / TimeSpan.TicksPerMillisecond;
        if (diff >= 0 && LastId < IdMax)
        {
            ++LastId;
        }
        else
        {
            LastId = 1;
            LastAt = (diff >= 0 ? LastAt : now).AddMilliseconds(1);
        }
        return $"{MakerId}{LastAt:yyyyMMddHHmmssfff}{LastId:d3}";
    }

    public string[] MakeMany(int count)
    {
        var now = DateTime.Now;
        long diff = (LastAt - now).Ticks / TimeSpan.TicksPerMillisecond;
        if (diff <= 0)
        {
            LastAt = now.AddMilliseconds(1);
        }
        LastId = 0;
        var result = new string[count];
        for (int i = 0; i < count; ++i)
        {
            if (LastId < IdMax)
            {
                ++LastId;
            }
            else
            {
                LastId = 1;
                LastAt = LastAt.AddMilliseconds(1);
            }
            result[i] = $"{MakerId}{LastAt:yyyyMMddHHmmssfff}{LastId:d3}";
        }

        return result;
    }
}
