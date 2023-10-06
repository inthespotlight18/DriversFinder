using System.Management;
using System.ServiceProcess;

namespace DriversFinder.Pages;

public partial class Finder : ContentPage
{
	public Finder()
	{
		InitializeComponent();
	}

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
    private void OnFinderBtnClicked(object sender, EventArgs e)
    {
        //var scope = Connect("LAPTOP-R94KE44G");
        test();
        ServicesList();
    }

    public void ServicesList()
    {
        ServiceController[] scDevices;
        scDevices = null;


        if (OperatingSystem.IsWindows())
        {
            scDevices = ServiceController.GetDevices();
        }
        

        int numAdapter = 0,
            numFileSystem = 0,
            numKernel = 0,
            numRecognizer = 0;

        // Display the list of device driver services.
        Console.WriteLine("Device driver services on the local computer:");

        if (OperatingSystem.IsWindows())
        {
            foreach (ServiceController scTemp in scDevices)
            {
                // Display the status and the service name, for example,
                //   [Running] PCI Bus Driver
                //             Type = KernelDriver

                Console.WriteLine(" [{0}] {1}",
                                  scTemp.Status, scTemp.DisplayName);
                Console.WriteLine("           Type = {0}", scTemp.ServiceType);

                // Update counters using the service type bit flags.
                if ((scTemp.ServiceType & ServiceType.Adapter) != 0)
                {
                    numAdapter++;
                }
                if ((scTemp.ServiceType & ServiceType.FileSystemDriver) != 0)
                {
                    numFileSystem++;
                }
                if ((scTemp.ServiceType & ServiceType.KernelDriver) != 0)
                {
                    numKernel++;
                }
                if ((scTemp.ServiceType & ServiceType.RecognizerDriver) != 0)
                {
                    numRecognizer++;
                }
            }
        }

        var l = scDevices.Length;
        var NumAdapter = numAdapter;
        var NumFileSystem = numFileSystem;
        var NumKernel = numKernel;  
        var NumRecognizer = numRecognizer;       

        //Console.WriteLine();
        //Console.WriteLine("Total of {0} device driver services", scDevices.Length); //$"Total of  device driver services : {scDevices.Length}";
        //Console.WriteLine("  {0} are adapter drivers", numAdapter);
        //Console.WriteLine("  {0} are file system drivers", numFileSystem);
        //Console.WriteLine("  {0} are kernel drivers", numKernel);
        //Console.WriteLine("  {0} are file system recognizer drivers", numRecognizer);
    }


    public static ManagementScope getScope(string machineName)//LAPTOP-R94KE44G   LAPTOP-R94KE44G // Console.WriteLine($"Error loading users details: {ex}");
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

    public void test()
    {
        //ManagementScope scope = null;
        //if (OperatingSystem.IsWindows())
        //{
        //    scope =
        //    new ManagementScope(
        //    "\\\\LAPTOP-R94KE44G\\root\\cimv2");
        //    scope.Connect();
        //}
        ManagementScope scope = getScope("LAPTOP-R94KE44G"); //LAPTOP-R94KE44G



        // Use this code if you are connecting with a
        // different user name and password:
        //
        // ManagementScope scope =
        //    new ManagementScope(
        //        "\\\\FullComputerName\\root\\cimv2", options);
        // scope.Connect();

        //Query system for Operating System information
        ObjectQuery query = new ObjectQuery(
                    "SELECT * FROM Win32_OperatingSystem");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    var PC = m["csname"];
                    // Display the remote computer information
                    Console.WriteLine("Computer Name : {0}",
                        m["csname"]);
                    Console.WriteLine("Windows Directory : {0}",
                        m["WindowsDirectory"]);
                    Console.WriteLine("Operating System: {0}",
                        m["Caption"]);
                    Console.WriteLine("Version: {0}", m["Version"]);
                    Console.WriteLine("Manufacturer : {0}",
                        m["Manufacturer"]);
                }
    }





}