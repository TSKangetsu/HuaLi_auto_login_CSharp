using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;

namespace PCI_IP_module
{
    class IP_module
    {
        private const string IPv4RegularExpression = "^(?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))$";
        private string Device { get; set; }
        private string Target_Device { get; set; }
        private string[] IPAddresses { get; set; }
        public string IPAddress { get; set; }
        private string query_Devices { get; set; }
        private string usb_is { get; set; }
        public IP_module(bool Include_USB = false)
        {
            string Usb_query = "SELECT * FROM Win32_NetworkAdapter WHERE (PNPDeviceID LIKE 'USB%')";
            ManagementObjectCollection ins1 = new ManagementObjectSearcher(Usb_query).Get();
            foreach (ManagementObject usb_info in ins1)
            {
                usb_is = usb_info["Description"] as string;
            }
            if (usb_is == null)
            {
                Include_USB = false;
            }
            else
            {
                Include_USB = true;
            }
            if (Include_USB == false)
            {
                query_Devices = "SELECT * FROM Win32_NetworkAdapter WHERE (PNPDeviceID LIKE 'PCI%') AND (NOT (Description LIKE '%Wireless%'))";
            }
            else
            {
                query_Devices = "SELECT * FROM Win32_NetworkAdapter WHERE (PNPDeviceID LIKE 'USB%')";
            }
            ManagementObjectCollection True_NETWork_Adapter = new ManagementObjectSearcher(query_Devices).Get();
            foreach (ManagementObject True_Adapter in True_NETWork_Adapter)
            {
                Device = True_Adapter["Description"] as string;
            }
            ManagementObjectCollection Target_Adapter_info = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description=" + "'" + Device + "'").Get();
            foreach (ManagementObject Target_Adapter in Target_Adapter_info)
            {
                String[] IPCollection = Target_Adapter["IPAddress"] as String[]; // IP地址
                if (IPCollection != null)
                {
                    foreach (String adress in IPCollection)
                    {
                        Match match = Regex.Match(adress, IPv4RegularExpression);
                        if (match.Success)
                        {
                            IPAddress = adress;
                        }
                    }
                }
            }
        }
    }
}
}
