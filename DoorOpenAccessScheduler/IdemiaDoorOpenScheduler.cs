using System;
using System.ServiceProcess;
using System.Timers;
using DoorOpenAccessScheduler.Data;
using DoorOpenAccessScheduler.Helpers;

namespace DoorOpenAccessScheduler
{
    public partial class IdemiaDoorOpenScheduler : ServiceBase
    {
        private Timer _timer;
        private DateTime _lastRun;

        public IdemiaDoorOpenScheduler()
        {
            InitializeComponent();
        }

        internal void DebugService(string[] args)
        {
            OnStart(args);
            Console.ReadLine();
        }

        private static void LoadOpenDoorScheduleToDevices()
        {            
            var schedule = ConfigurationHelper.DoorOpenSchedule;
            var devices = DataAccess.GetBiometricDevices();            

            var weekSchedule = schedule.GetWeekSchedule();
            foreach (var biometricDevice in devices)
            {
                Console.WriteLine($"Setting Open Door Schedule for {biometricDevice.IPAddress}");
                biometricDevice.SetDoorSchedule(weekSchedule);
                Console.WriteLine($"Complete: {biometricDevice.IPAddress}");
            }
        }        

        protected override void OnStart(string[] args)
        {
            ConfigurationHelper.ServiceLastRun = DateTime.Now.AddDays(-1);
            _timer = new Timer( 10 * 1000); //Default every 24 hours            
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            Console.WriteLine("Service started...");
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _lastRun = ConfigurationHelper.ServiceLastRun;
            if (_lastRun.Date >= DateTime.Now.Date) return;
            _timer.Stop();

            //Do work
            LoadOpenDoorScheduleToDevices();

            ConfigurationHelper.ServiceLastRun = DateTime.Now;            
            _timer.Start();

        }

        protected override void OnStop()
        {
        }
    }
}
