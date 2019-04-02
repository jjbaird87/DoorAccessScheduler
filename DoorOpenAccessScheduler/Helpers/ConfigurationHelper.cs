using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using DoorOpenAccessScheduler.Data;

namespace DoorOpenAccessScheduler.Helpers
{
    public static class ConfigurationHelper
    {
        private const string ConfigFileName = "DoorOpenAccessScheduler.exe.Config";

        public static DoorOpenSchedule DoorOpenSchedule
        {
            get
            {
                var doorOpenScheduleSetting = GetSetting("OpenDoorSchedule");
                if (doorOpenScheduleSetting == string.Empty)
                {
                    //initialize new schedule
                    var doorOpenSchedule = new DoorOpenSchedule
                    {
                        //Standard Schedule
                        DayOfTheWeekSlots = new List<DaySlot>
                    {
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Sunday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}
                            }
                        },
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Monday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}
                            }
                        },
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Tuesday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}
                            }
                        },
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Wednesday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}

                            }
                        },
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Thursday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}
                            }
                        },
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Friday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}
                            }
                        },
                        new DaySlot
                        {
                            DayOfWeek = DayOfWeek.Saturday,
                            Slots = new List<Slot>()
                            {
                                new Slot {StartTime = "060000", EndTime = "180000"}
                            }
                        }
                    },
                        HolidayExclusions = new List<Exclusion>
                    {
                        new Exclusion
                        {
                            Id = 0,
                            Name = "Christmas", StartDateTime = new DateTime(2019, 12, 25, 00, 00, 00),
                            EndDateTime = new DateTime(2019, 12, 25, 23, 59, 59),
                            Slots = new List<Slot>{new Slot { StartTime = "123000", EndTime ="170000" } }
                        }
                    }
                    };

                    
                    DoorOpenSchedule = doorOpenSchedule;                   

                    return doorOpenSchedule;
                }
                else
                {
                    var doorOpenSchedule = Utils.DeserializeObject<DoorOpenSchedule>(doorOpenScheduleSetting);
                    for (var i = 0; i < doorOpenSchedule.HolidayExclusions.Count; i++)
                    {
                        doorOpenSchedule.HolidayExclusions[i].Id = (uint)i;
                    }

                    return doorOpenSchedule;
                }
            }
            set
            {
                AddOrUpdateAppSettings("OpenDoorSchedule", Utils.SerializeObject(value));
                ServiceLastRun = DateTime.Now.AddDays(-1);
            }
            
        }

        public static DateTime ServiceLastRun
        {
            get => DateTime.Parse(GetSetting("ServiceLastRun"));
            set => AddOrUpdateAppSettings("ServiceLastRun", value.ToString(CultureInfo.InvariantCulture));
        }

        public static string ConnectionString => GetSetting("MorphoManagerConnectionString");

        private static string GetSetting(string settingName)
        {
            var fileMap = new ExeConfigurationFileMap {ExeConfigFilename = ConfigFileName};
            //Path to your config file
            var configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var doorOpenScheduleSetting = configuration.AppSettings.Settings[settingName].Value;
            return doorOpenScheduleSetting;
        }

        private static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = ConfigFileName };
                //Path to your config file
                var configuration =
                    ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                var settings = configuration.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configuration.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }        
    }
}
