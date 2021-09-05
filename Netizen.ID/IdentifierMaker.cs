using System;

namespace Netizen.ID
{
    public class IdentifierMaker
    {
        public long MakerId { get; private set; }
        public long LastId { get; private set; }
        public long LastAt { get; private set; }

        public IdentifierMaker(long makerId)
        {
            MakerId = makerId;
            LastId = 0;
            LastAt = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public long Make()
        {
            long mid = MakerId << (41 + 12);
            long now = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            if (LastAt == now)
            {
                ++LastId;
            }
            else
            {
                LastId = 0;
                LastAt = now;
            }

            return mid | (LastAt << 12) | LastId;
        }
    }
}
