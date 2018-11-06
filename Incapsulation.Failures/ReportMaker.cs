using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{

    public enum FailureType
    {
        unexpectedShutdown = 0,
        nonResponding = 1,
        hardwareFailures = 2,
        connectionProblems = 3
        /// 0 for unexpected shutdown,
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems

    }

    public struct Device
    {
        public static bool IsFailureSerious(FailureType ft)
        {
            return (FailureType.hardwareFailures == ft || FailureType.unexpectedShutdown == ft);

        }

        public readonly int Id;
        public readonly string Name;
        public readonly FailureType failureType;
        public readonly DateTime times;

        public Device(int Id, string Name, int failureType, object[] times)
        {
            this.Id = Id;
            this.Name = Name;
            this.failureType = (FailureType)failureType;
            this.times = Common.GetDate(times);
        }

    }

    public class Common
    {

        public static DateTime GetDate(object[] times)
        {
            return new DateTime(
                (int)times[2],
                (int)times[1],
                (int)times[0]
            );
        }

        public static bool Earlier(DateTime d1, DateTime d2)
        {
            return (d1 - d2).TotalDays < 0;
        }
    }

    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes, 
            int[] deviceId, 
            object[][] times,
            List<Dictionary<string, object>> devices)
        {

            List<Device> lDevices = new List<Device>();
            foreach (var device in devices)
            {
                int i = deviceId.First(id => id == (int)device["DeviceId"]);
                if (i > -1)
                {
                    lDevices.Add(new Device(
                        (int)device["DeviceId"],
                        (string)device["Name"],
                        failureTypes[i],
                        times[i]
                    ));
                }
            }


            return FindDevicesFailedBeforeDate(
                Common.GetDate(new object[] { day, month, year }),
                lDevices
            );
        }

        public static List<string> FindDevicesFailedBeforeDate(
            DateTime date,
            List<Device> devices)
        {
            var result = new List<string>();
            foreach (Device device in devices)
            {
                if (Device.IsFailureSerious(device.failureType) && Common.Earlier(device.times, date))
                    result.Add(device.Name);
            }

            return result;
        }
    }
}
