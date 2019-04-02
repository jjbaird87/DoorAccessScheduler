using System;
using System.Collections.Generic;

namespace DoorOpenAccessScheduler.Data
{
    [Serializable]
    public class Exclusion
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<Slot> Slots { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
