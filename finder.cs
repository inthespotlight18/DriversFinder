//using Lucene.Net.Search;
using System;
using System.Diagnostics;

using System.Management;


namespace DriversFinder
{
    public class finder
    {

        public static string[] _scopes = new string[] { "root\\CIMV2", "SELECT * FROM Win32_Service" };
        //public static void Main(string[] args)
        //{
        //    ManagementObjectSearcher s =
        //        new ManagementObjectSearcher(
        //        _scopes, new EnumerationOptions(
        //        null, System.TimeSpan.MaxValue,
        //        1, true, false, true,
        //        true, false, true, true));

        //    foreach (ManagementObject service in s.Get())
        //    {
        //        // show the service
        //        Console.WriteLine(service.ToString());
        //    }
        //}



        public static ManagementScope Connect(string machineName)//LAPTOP-R94KE44G   LAPTOP-R94KE44G // Console.WriteLine($"Error loading users details: {ex}");
        {
            if (OperatingSystem.IsWindows())
            {
               // string path = 
                var scope = new ManagementScope(@"\\LAPTOP-R94KE44G\root\cimv2") //(@"\\{0}\root\cimv2")
                {
                    Options =
                    {
                        Impersonation = ImpersonationLevel.Impersonate,
                        EnablePrivileges = true
                    }
                };

                try
                {
                    scope.Connect();
                }
                catch (Exception exc)
                {
                    throw new SystemException("Problem connecting WMI scope on " + machineName + ".", exc);
                }

                return scope;
            }
            return null;

        }







    }
    

}

 