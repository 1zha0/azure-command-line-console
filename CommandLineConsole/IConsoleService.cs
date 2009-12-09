using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommandLineConsole.Common;

namespace CommandLineConsole
{
    [ServiceContract]
    public interface IConsoleService
    {

        [OperationContract]
        string processCommand(CommandType command);
    }
}
