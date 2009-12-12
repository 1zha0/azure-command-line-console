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
            if (ct.Command == null)
            {
                return "Not implemented yet.";
            }
            Process process = new Process();
            string output = null;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.ErrorDialog = false;
            process.StartInfo.FileName = "cmd";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "/c " + "\"" + (ct.Path == null ? (ct.Command.Contains(" ") ? "\"" + ct.Command + "\"" : ct.Command) : "\"" + ct.Path + "\\" + ct.Command + "\"") + (ct.Parameters == null ? null : " \"" + ct.Parameters + "\"") + "\"";
            process.EnableRaisingEvents = false;
            try
            {
                process.Start();
                output += process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                output = ex.ToString();
            }
            return output;
        }
    }
}
