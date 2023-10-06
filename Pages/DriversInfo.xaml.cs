using System.ServiceProcess;

namespace DriversFinder.Pages;

public partial class DriversInfo : ContentPage
{
	public DriversInfo()
	{
		InitializeComponent();
	}
    private void OnDriversInfoBtnClicked(object sender, EventArgs e)
    {
        test();
    }

    public void test()
	{
        DriveInfo[] allDrives = DriveInfo.GetDrives();

        foreach (DriveInfo d in allDrives)
        {
            var driverName = d.Name;
            var driverType = d.DriveType.ToString();
            var driverVolumeLabel = d.VolumeLabel;
            var driverFormat = d.DriveFormat;
            var driverAvailableFreeSpace = d.AvailableFreeSpace;
            var driverFreeSpaceLabel = d.TotalFreeSpace;
            var driverTotalSize = d.TotalSize;

            DriverName.Text = driverName;
            DriverType.Text = driverType;
            DriverVolumeLabel.Text = driverVolumeLabel;


            Console.WriteLine("Drive {0}", driverName);
            Console.WriteLine("  Drive type: {0}", driverType);
            if (d.IsReady == true)
            {
                Console.WriteLine("  Volume label: {0}", driverVolumeLabel);
                Console.WriteLine("  File system: {0}", driverFormat);
                Console.WriteLine(
                    "  Available space to current user:{0, 15} bytes",
                   driverAvailableFreeSpace);

                Console.WriteLine(
                    "  Total available space:          {0, 15} bytes",
                    driverFreeSpaceLabel);

                Console.WriteLine(
                    "  Total size of drive:            {0, 15} bytes ",
                    driverTotalSize);
            }
        }



        /*
         * 
        ServiceController[] scDevices;
        scDevices = ServiceController.GetDevices();

        int numAdapter = 0,
            numFileSystem = 0,
            numKernel = 0,
            numRecognizer = 0;

        // Display the list of device driver services.
        Console.WriteLine("Device driver services on the local computer:");

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

        var l = scDevices.Length;
        var NumAdapter = numAdapter;
        var NumFileSystem = numFileSystem;
        var NumKernel = numKernel;  
        var NumRecognizer = numRecognizer;


        */

        //Console.WriteLine();
        //Console.WriteLine("Total of {0} device driver services", scDevices.Length); //$"Total of  device driver services : {scDevices.Length}";
        //Console.WriteLine("  {0} are adapter drivers", numAdapter);
        //Console.WriteLine("  {0} are file system drivers", numFileSystem);
        //Console.WriteLine("  {0} are kernel drivers", numKernel);
        //Console.WriteLine("  {0} are file system recognizer drivers", numRecognizer);
    }
}