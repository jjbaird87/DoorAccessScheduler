using System;
using System.ServiceProcess;

namespace DoorOpenAccessScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                if (Environment.UserInteractive)
                {
                    var serviceManager = new IdemiaDoorOpenScheduler();
                    serviceManager.DebugService(args);
                }
                else
                {
                    var servicesToRun = new ServiceBase[]
                    {
                        new IdemiaDoorOpenScheduler()
                    };
                    ServiceBase.Run(servicesToRun);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}