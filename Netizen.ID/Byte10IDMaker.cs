using System;

namespace Netizen.ID;

public class Byte10IDMaker
{
    //public const int TimestampLength = 42;
    public const int TimestampShift = RollLength + IdLength;
    public const int RollLength = 5;
    public const int IdLength = 16;
    public const long IdMax = (1 << IdLength) - 1;

    public short MakerId { get; private set; }
    public long LastId { get; private set; }
    public long LastAt { get; private set; }

    public Byte10IDMaker(short makerId)
    {
        MakerId = makerId;
        LastId = 1;
        LastAt = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }

    private byte[] NewNow()
    {
        byte[] result = new byte[10];

        // MakerId
        result[0] = (byte)((MakerId >> 8) & 0xff);
        result[1] = (byte)(MakerId & 0xff);

        // TimeStamp + Id + Roll
        long roll = Random.Shared.Next(1, 0b11111);
        long low = (LastAt << TimestampShift) | (LastId << RollLength) | roll;
        for (int i = 0; i < 8; ++i)
        {
            result[9 - i] = (byte)((low >> (i * 8)) & 0xff);
        }

        return result;
    }

    public byte[] Make()
    {
        long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        if (LastAt >= now && LastId < IdMax)
        {
            ++LastId;
        }
        else
        {
            LastId = 1;
            LastAt = Math.Max(now, LastAt) + 1;
        }

        return NewNow();
    }

    public byte[][] MakeMany(long count)
    {
        byte[][] result = new byte[count][];

        long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        if (LastAt <= now)
        {
            LastAt = now + 1;
        }
        LastId = 0;

        for (int i = 0; i < count; i++)
        {
            if (LastId < IdMax)
            {
                ++LastId;
            }
            else
            {
                LastId = 1;
                ++LastAt;
            }

            result[i] = NewNow();
        }

        return result;
    }
}
