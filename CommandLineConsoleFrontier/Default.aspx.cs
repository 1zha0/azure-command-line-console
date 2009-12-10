using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommandLineConsoleFrontier.ConsoleServiceReference;

namespace CommandLineConsoleFrontier
{
    public partial class _Default : System.Web.UI.Page
    {
        ConsoleServiceClient csr;
        CommandType customizedCommand = new CommandType();
        CommandType predefinedCommand = new CommandType();

        protected void Page_Load(object sender, EventArgs e)
        {
            csr = new ConsoleServiceClient();
        }

        protected void processCustomizedCommandButton_Click(object sender, EventArgs e)
        {
            customizedCommand.Path = (pathTextBox.Text.Length != 0 ? pathTextBox.Text : null);
            customizedCommand.Command = (commandTextBox.Text.Length != 0 ? commandTextBox.Text : null);
            customizedCommand.Parameters = (parametersTextBox.Text.Length != 0 ? parametersTextBox.Text : null);
            try
            {
                resultTextBox.Text = csr.processCommand(customizedCommand);
            }
            catch (Exception ex)
            {
                resultTextBox.Text = ex.ToString();
            }
        }

        protected void applicationsCommandButton_Click(object sender, EventArgs e)
        {
            predefinedCommand.Path = "precomm://";
            predefinedCommand.Command = "Applications";
            resultTextBox.Text = csr.processCommand(predefinedCommand);
        }

        protected void processesCommandButton_Click(object sender, EventArgs e)
        {
            predefinedCommand.Path = "precomm://";
            predefinedCommand.Command = "Processes";
            resultTextBox.Text = csr.processCommand(predefinedCommand);
        }

        protected void servicesCommandButtom_Click(object sender, EventArgs e)
        {
            predefinedCommand.Path = "precomm://";
            predefinedCommand.Command = "Services";
            resultTextBox.Text = csr.processCommand(predefinedCommand);
        }

        protected void performanceCommandButton_Click(object sender, EventArgs e)
        {
            predefinedCommand.Path = "precomm://";
            predefinedCommand.Command = "Performance";
            resultTextBox.Text = csr.processCommand(predefinedCommand);
        }

        protected void networkingCommandButton_Click(object sender, EventArgs e)
        {
            predefinedCommand.Path = "precomm://";
            predefinedCommand.Command = "Networking";
            resultTextBox.Text = csr.processCommand(predefinedCommand);
        }

        protected void usersCommandButton_Click(object sender, EventArgs e)
        {
            predefinedCommand.Path = "precomm://";
            predefinedCommand.Command = "Users";
            resultTextBox.Text = csr.processCommand(predefinedCommand);
        }
    }
}
