using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using CommandLineConsole.Common;

namespace CommandLineConsole
{
    public class ConsoleService : IConsoleService
    {

        public string processCommand(CommandType command)
        {
            // Run predefiend commands
            if (command.Path != null && command.Path.CompareTo(PredefinedCommands.ProcessPredefinedCommand.prefixOfPredefinedCommand) == 0)
            {
                return PredefinedCommands.ProcessPredefinedCommand.processPredefinedCommands(command.Command);
            }
            // Run customized commands
            else
            {
                return CustomizedCommands.ProcessCustomizedCommand.processCustomizedCommand(command);
            }
        }
    }
}
