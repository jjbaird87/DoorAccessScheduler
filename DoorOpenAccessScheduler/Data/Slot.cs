using System;

namespace DoorOpenAccessScheduler.Data
{
    [Serializable]
    public class Slot
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
