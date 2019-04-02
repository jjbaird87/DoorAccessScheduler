using System;
using System.Collections.Generic;
using System.Linq;

namespace DoorOpenAccessScheduler.Data
{
    [Serializable]
    public class DaySlot
    {
        private List<Slot> _slots;

        public DayOfWeek DayOfWeek { get; set; }

        public List<Slot> Slots
        {
            get => _slots == null ? null :
                _slots.Count > 10 ? _slots.Take(10).ToList() : _slots;
            set => _slots = value;
        }

        public override string ToString()
        {
            return DayOfWeek.ToString();
        }
    }
}
