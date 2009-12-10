using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLineConsoleClient.ConsoleServiceReference;

namespace AzureCommandLineConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleServiceClient csr = new ConsoleServiceClient();
            CommandType comm = new CommandType();
            comm.Command = "dir";
            comm.Parameters = "c:\\";
            System.Console.Write(csr.processCommand(comm));
            System.Console.ReadLine();
            //comm = new CommandType();
            //comm.Path = "precomm://";
            //comm.Command = "Processes";
            //System.Console.Write(csr.processCommand(comm));
            //System.Console.ReadLine();
            //comm = new CommandType();
            //comm.Path = "precomm://";
            //comm.Command = "Services";
            //System.Console.Write(csr.processCommand(comm));
            //System.Console.ReadLine();
            //comm = new CommandType();
            //comm.Path = "precomm://";
            //comm.Command = "Networking";
            //System.Console.Write(csr.processCommand(comm));
            //System.Console.ReadLine();
            //comm = new CommandType();
            //comm.Path = "precomm://";
            //comm.Command = "Performance";
            //System.Console.Write(csr.processCommand(comm));
            //System.Console.ReadLine();
        }
    }
}
