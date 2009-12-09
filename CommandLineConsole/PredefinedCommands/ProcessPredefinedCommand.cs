using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Management;
using CommandLineConsole.Common;
using CommandLineConsole.CustomizedCommands;
using System.Diagnostics;

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
            string str = String.Format("{0,-25} {1,10} {2,-15} {3,9}{4}", "Process ID", "Processes", "User", "CPU Time", "\n");
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
