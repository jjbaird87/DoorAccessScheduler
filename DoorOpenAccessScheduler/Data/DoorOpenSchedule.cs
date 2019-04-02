using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DoorOpenAccessScheduler.Helpers;
using Morpho.MorphoAccess.Maci;

namespace DoorOpenAccessScheduler.Data
{
    [Serializable]
    public class DoorOpenSchedule
    {
        public List<DaySlot> DayOfTheWeekSlots { get; set; }
        public List<Exclusion> HolidayExclusions { get; set; }

        public WeekSchedule GetWeekSchedule()
        {            
            var weekSchedule = new WeekSchedule();
            foreach (var dayOfTheWeekSlot in DayOfTheWeekSlots)
            {
                var trv = GetTimeRangeVector(
                    DetermineIfExcluded(dayOfTheWeekSlot.DayOfWeek, out var exclusion)
                        ? exclusion.Slots
                        : dayOfTheWeekSlot.Slots, weekSchedule);

                weekSchedule.SetDaySchedule(GetScheduleDay(dayOfTheWeekSlot.DayOfWeek), trv);
            }

            return weekSchedule;
        }

        private static TimeRangeVector GetTimeRangeVector(IEnumerable<Slot> slots, WeekSchedule weekSchedule)
        {
            var trv = new TimeRangeVector();

            foreach (var slot in slots)
            {
                string start, end;
                if (slot.StartTime == string.Empty)
                    start = string.Empty;
                else
                    start = DateTime.ParseExact(slot.StartTime, "HHmmss", CultureInfo.InvariantCulture)
                        .RoundDown(new TimeSpan(0, 15, 0)).ToString("HHHmmss");
                if (slot.EndTime == string.Empty)
                    end = string.Empty;
                else
                    end = DateTime.ParseExact(slot.EndTime, "HHmmss", CultureInfo.InvariantCulture)
                        .RoundDown(new TimeSpan(0, 15, 0)).ToString("HHmmss");
                trv.Add(new TimeRange(start, end));
            }

            if (trv.Count == 0)
            {
                trv.Add(new TimeRange(string.Empty, string.Empty));
            }

            return trv;
        }

        private bool DetermineIfExcluded(DayOfWeek toAdd, out Exclusion outExclusion)
        {
            var excluded = false;
            var exclusions = HolidayExclusions
                .Where(i => i.StartDateTime <= DateTime.Now.AddDays(toAdd - DateTime.Now.DayOfWeek) && i.EndDateTime >= DateTime.Now.AddDays(toAdd - DateTime.Now.DayOfWeek)).ToList();
            foreach (var exclusion in exclusions)
            {
                if (exclusion.StartDateTime.DayOfWeek <= toAdd && exclusion.EndDateTime.DayOfWeek >= toAdd)
                    excluded = true;
            }

            outExclusion = excluded ? exclusions.First() : null;
            return excluded;
        }

        private ScheduleDay GetScheduleDay(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return ScheduleDay.SCHEDULE_SUNDAY;
                case DayOfWeek.Monday:
                    return ScheduleDay.SCHEDULE_MONDAY;
                case DayOfWeek.Tuesday:
                    return ScheduleDay.SCHEDULE_TUESDAY;
                case DayOfWeek.Wednesday:
                    return ScheduleDay.SCHEDULE_WEDNESDAY;
                case DayOfWeek.Thursday:
                    return ScheduleDay.SCHEDULE_THURSDAY;
                case DayOfWeek.Friday:
                    return ScheduleDay.SCHEDULE_FRIDAY;
                case DayOfWeek.Saturday:
                    return ScheduleDay.SCHEDULE_SATURDAY;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null);
            }
        }
    }
}
