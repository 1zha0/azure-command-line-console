using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using CommandLineConsole.Common;

namespace CommandLineConsole.CustomizedCommands
{
    public static class ProcessCustomizedCommand
    {
        public static string processCustomizedCommand(CommandType ct)
        {
            Process process = new Process();
            string output = null;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "cmd";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "/c " + "\""+ ct.Path + ct.Command + "\" " + ct.Parameters;
            process.EnableRaisingEvents = false;
            process.Start();
            output = process.StandardOutput.ReadToEnd();
            process.Close();
            return output;
        }
    }
}
