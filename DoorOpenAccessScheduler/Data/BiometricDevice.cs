using System;
using Morpho.MorphoAccess.Maci;

namespace DoorOpenAccessScheduler.Data
{
    internal class BiometricDevice
    {
        public Guid ID { get; set; }
        public string IPAddress { get; set; }
        public ushort Port { get; set; }

        public void SetDoorSchedule(WeekSchedule weekSchedule)
        {
            using (var terminal = new Terminal())
            {
                terminal.Connect(new TcpConnectionParameters(IPAddress, Port), ApplicationProtocol.APPLICATION_MA5G);
                var scheduleManager = terminal.CreateScheduleManager();

                //Erase schedules first
                scheduleManager.DeleteDoorOpenSchedule();
                //Set New Schedule
                scheduleManager.StoreDoorOpenSchedule(weekSchedule);
            }
        }
    }
}
