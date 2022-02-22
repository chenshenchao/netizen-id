using System;

namespace Netizen.ID
{
    /// <summary>
    /// 
    /// </summary>
    public class IdentifierMaker
    {
        public const int TimestampLength = 41;
        public const int IdLength = 12;
        public const int MakerIdLength = 10;
        public const long IdMax = (1 << IdLength) - 1;

        public long MakerId { get; private set; }
        public long LastId { get; private set; }
        public long LastAt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="makerId"></param>
        public IdentifierMaker(long makerId=0)
        {
            MakerId = makerId;
            LastId = 1;
            LastAt = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Make()
        {
            long mid = MakerId << (TimestampLength + IdLength);
            long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (LastAt == now)
            {
                ++LastId;
            }
            else
            {
                LastId = 1;
                LastAt = now;
            }

            return mid | (LastAt << IdLength) | LastId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public long[] MakeMany(long count)
        {
            long[] result = new long[count];
            long mid = MakerId << (TimestampLength + IdLength);
            long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (LastAt == now)
            {
                ++LastAt;
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
                    LastId = 0;
                    ++LastAt;
                }
                result[i] = mid | (LastAt << IdLength) | LastId;
            }
            return result;
        }
    }
}
