using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CommandLineConsole.Common
{
    [DataContract]
    public class CommandType
    {
        string path = null;
        string command = null;
        string parameters = null;

        public CommandType(string c)
        {
            this.command = c;
        }

        public CommandType(string c, string ps)
        {
            this.command = c;
            this.parameters = ps;
        }

        public CommandType(string pa, string c, string ps)
        {
            this.path = pa;
            this.command = c;
            this.parameters = ps;
        }

        [DataMember]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        [DataMember]
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        [DataMember]
        public string Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
    }
}
