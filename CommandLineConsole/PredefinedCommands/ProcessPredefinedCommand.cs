using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Management;
using CommandLineConsole.Common;
using CommandLineConsole.CustomizedCommands;
using System.Diagnostics;
using CommandLineConsole.Misc;

namespace CommandLineConsole.PredefinedCommands
{
    public static class ProcessPredefinedCommand
    {
        public static string prefixOfPredefinedCommand = "precomm://";

        private static PerformanceCounter ct = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private static PerformanceCounter pt = new PerformanceCounter("Processor", "% Privileged Time", "_Total");
        private static PerformanceCounter ut = new PerformanceCounter("Processor", "% User Time", "_Total");
        private static PerformanceCounter ql = new PerformanceCounter("System", "Processor Queue Length");
        private static PerformanceCounter pb = new PerformanceCounter("Process", "Private Bytes", "_Total");
        private static PerformanceCounter iw = new PerformanceCounter("Process", "IO Write Operations/sec", "_Total");
        private static PerformanceCounter dq = new PerformanceCounter("PhysicalDisk", "Avg. Disk Queue Length", "_Total");
        private static PerformanceCounter rc = new PerformanceCounter("Memory", "Available MBytes");


        public static string processPredefinedCommands(string command)
        {
            CommandItem pci;
            if (Enum.IsDefined(typeof(CommandItem), command))
            {
                pci = (CommandItem)Enum.Parse(typeof(CommandItem), command, true);
            }
            else
            {
                pci = CommandItem.Unpredefined;
            }
            switch (pci)
            {
                case CommandItem.Applications:
                    return getApplications();
                case CommandItem.Networking:
                    return getNetworking();
                case CommandItem.Performance:
                    return getPerformance();
                case CommandItem.Processes:
                    return getProcesses();
                case CommandItem.Processors:
                    return getProcessors();
                case CommandItem.Services:
                    return getServices();
                case CommandItem.Users:
                    return getUsers();
                default:
                    return "Unpredefined commands!";
            }
        }

        private static string getApplications()
        {
            return "Not implemented yet.";
        }

        private static string getProcesses()
        {
            ManagementClass processes = new ManagementClass("Win32_process");
            string str = String.Format("{0,-25} {1,10} {2,-15} {3,9}{4}", "Processes", "Process ID", "User", "CPU Time", "\n");
            str += String.Format("========================= ========== =============== =========\n");
            foreach (ManagementObject o in processes.GetInstances())
            {
                string[] owner = new string[2];
                o.InvokeMethod("GetOwner", (object[])owner);
                TimeSpan ts = new TimeSpan((long)((UInt64)o["KernelModeTime"] + (UInt64)o["UserModeTime"]));
                DateTime dt = DateTime.MinValue.Add(ts);
                str += String.Format("{0,-25} {1,10} {2,-15} {3,9}{4}", o["Name"], o["ProcessId"], owner[0], dt.ToString("H:mm:ss"), "\n");
            }
            return str;
        }

        private static string getProcessors()
        {
            //generate output data
            CPUInfo cpuInfo = new CPUInfo();


            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection objCol = mgmt.GetInstances();
            foreach (ManagementObject obj in objCol)
            {
                if (cpuInfo.Id == String.Empty)
                {
                    // only return processor id from first CPU
                    cpuInfo.Id = obj.Properties["ProcessorId"].Value.ToString();
                }
                if (cpuInfo.Socket == String.Empty)
                {
                    // only return socket designation from first CPU
                    cpuInfo.Socket = obj.Properties["SocketDesignation"].Value.ToString();
                }
                if (cpuInfo.Name == String.Empty)
                {
                    // only return name from first CPU
                    cpuInfo.Name = obj.Properties["Name"].Value.ToString();
                }
                if (cpuInfo.Manufacturer == String.Empty)
                {
                    // only return manufacturer from first CPU
                    cpuInfo.Manufacturer = obj.Properties["Manufacturer"].Value.ToString();
                }
                if (cpuInfo.Descr == String.Empty)
                {
                    // only return description from first CPU
                    cpuInfo.Descr = obj.Properties["Manufacturer"].Value.ToString();
                }
                if (cpuInfo.Speed == 0)
                {
                    // only return clock speed from first CPU
                    cpuInfo.Speed = Convert.ToInt32(obj.Properties["CurrentClockSpeed"].Value.ToString());
                }
                if (cpuInfo.ArchId == -1)
                {
                    // only return architecture from first CPU
                    cpuInfo.ArchId = Convert.ToInt16(obj.Properties["Architecture"].Value.ToString());
                }
                if (cpuInfo.FamilyId == -1)
                {
                    // only return family from first CPU
                    cpuInfo.FamilyId = Convert.ToInt16(obj.Properties["Family"].Value.ToString());
                }
                if (cpuInfo.L2CacheSize == 0)
                {
                    // only return L2 cache size from first CPU
                    cpuInfo.L2CacheSize = Convert.ToInt32(obj.Properties["L2CacheSize"].Value.ToString());
                }
                if (cpuInfo.L3CacheSize == 0)
                {
                    // only return L3 cache size from first CPU
                    cpuInfo.L3CacheSize = Convert.ToInt32(obj.Properties["L3CacheSize"].Value.ToString());
                }
                if (cpuInfo.Cores == 0)
                {
                    // only return cpu cores from first CPU
                    cpuInfo.Cores = Convert.ToInt16(obj.Properties["NumberOfCores"].Value.ToString());
                }
                if (cpuInfo.Load == 0)
                {
                    // only return cpu load percentage from first CPU
                    cpuInfo.Load = Convert.ToInt16(obj.Properties["LoadPercentage"].Value.ToString());
                }
                if (cpuInfo.FSBClock == 0)
                {
                    // only return cpu fsb (external clock) speed from first CPU
                    cpuInfo.FSBClock = Convert.ToInt32(obj.Properties["ExtClock"].Value.ToString());
                }
            }

            string output = String.Format("{0,-25} {1,-14}{2}", "CPU ID:", cpuInfo.Id.ToString(), "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Manufacturer:", cpuInfo.Manufacturer.ToString(), "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Clock Speed:", cpuInfo.Speed.ToString() + "MHz", "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Architecture:", cpuInfo.Arch + " (" + cpuInfo.ArchId.ToString() + ")", "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Cores:", cpuInfo.Cores.ToString(), "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Description:", cpuInfo.Descr, "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU L2 Cache Size:", cpuInfo.L2CacheSize.ToString() + "KB", "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU L3 Cache Size:", cpuInfo.L3CacheSize.ToString() + "KB", "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Name:", cpuInfo.Name, "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Socket Type:", cpuInfo.Socket, "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Family:", cpuInfo.Family, "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU Load:", cpuInfo.Load.ToString() + "%", "\n");
            output += String.Format("{0,-25} {1,-14}{2}", "CPU FSB Clock:", cpuInfo.FSBClock.ToString() + "MHz", "\n");

            return output;
        }

        private static string getServices()
        {
            CommandType ct = new CommandType("net.exe", "start");
            return ProcessCustomizedCommand.processCustomizedCommand(ct);
        }

        private static string getPerformance()
        {
            // The first xx.NextValue() will always return zero. So it is necessary 
            // to move all initialize functions to the front of the class. By doing this,
            // in the current method, xx.NextValue() can be called repeatly, rather than 
            // initialize PerformanceCounter in this method, always making the first call of
            // xx.NextValue(), resulting zero value.
            string output = String.Format("{0,-25} {1,14}{2}", "CPU Usage:", ct.NextValue().ToString() + " %", "\n");
            output += String.Format("{0,-25} {1,14}{2}", "Kernel Mode Time:", pt.NextValue().ToString() + " %", "\n");
            output += String.Format("{0,-25} {1,14}{2}", "User Mode Time:", ut.NextValue().ToString() + " %", "\n");
            output += String.Format("{0,-25} {1,14}{2}", "Processor Queue Length:", ql.NextValue().ToString(), "\n");
            output += String.Format("{0,-25} {1,14}{2}", "IO Write Operations/sec:", iw.NextValue().ToString(), "\n");
            output += String.Format("{0,-25} {1,14}{2}", "Avg. Disk Queue Length:", dq.NextValue().ToString(), "\n");
            output += String.Format("{0,-25} {1,14}{2}", "Available Memory:", rc.NextValue().ToString() + " MB", "\n");
            return output;
        }

        private static string getNetworking()
        {
            string output = null;
            CommandType ct = new CommandType("netstat.exe");
            output = ProcessCustomizedCommand.processCustomizedCommand(ct);
            ct = new CommandType("netstat.exe", "-e");
            output += ProcessCustomizedCommand.processCustomizedCommand(ct);
            return output;
        }

        private static string getUsers()
        {
            return "Not implemented yet.";
        }
    }
}
