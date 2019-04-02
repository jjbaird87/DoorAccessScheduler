using System;
using System.Globalization;
using DoorOpenAccessScheduler.Data;

namespace DoorOpenAccessScheduler.UI
{
    public class SlotDisplay : Slot
    {
        public SlotDisplay(Slot slot)
        {
            base.StartTime = slot.StartTime;
            base.EndTime = slot.EndTime;
        }

        public SlotDisplay()
        {
            //Empty Constructor
        }

        public new string StartTime
        {
            get
            {
                try
                {
                    if (base.StartTime == string.Empty)
                        return string.Empty;
                    else
                    {
                        var startTime = DateTime.ParseExact(base.StartTime, "HHmmss", CultureInfo.InvariantCulture);
                        return startTime.ToString("hh:mm tt");
                    }
                }
                catch
                {
                    return base.StartTime;
                }                
            }
            set
            {
                try
                {
                    if (value == string.Empty)
                        base.StartTime = string.Empty;
                    else
                    {
                        var startTime = DateTime.Parse(value, CultureInfo.InvariantCulture);
                        base.StartTime = startTime.ToString("HHmmss");
                    }
                }
                catch
                {
                    base.StartTime = value;
                }

            }
        }

        public new string EndTime
        {
            get
            {
                try
                {
                    if (base.EndTime == string.Empty)
                        return string.Empty;
                    else
                    {
                        var endTime = DateTime.ParseExact(base.EndTime, "HHmmss", CultureInfo.InvariantCulture);
                        return endTime.ToString("hh:mm tt");
                    }
                }
                catch
                {
                    return base.EndTime;
                }                               
            }
            set
            {
                try
                {
                    if (value == string.Empty)
                        base.EndTime = string.Empty;
                    else
                    {
                        var endTime = DateTime.Parse(value,  CultureInfo.InvariantCulture);
                        base.EndTime = endTime.ToString("HHmmss");
                    }
                }
                catch
                {
                    base.EndTime = value;                    
                }
                               
            }
        }

        public Slot GetBase()
        {
            return new Slot {StartTime = base.StartTime, EndTime = base.EndTime};
        }
    }
}
