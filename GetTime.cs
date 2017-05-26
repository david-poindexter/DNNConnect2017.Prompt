using Dnn.PersonaBar.Prompt.Attributes;
using Dnn.PersonaBar.Prompt.Common;
using Dnn.PersonaBar.Prompt.Interfaces;
using Dnn.PersonaBar.Prompt.Models;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace DNNConnect2017.Prompt.Commands
{
    [ConsoleCommand("get-time", "dnn-connect", "Returns the Server Time", new string[] { "format" })]
    public class GetTime : ConsoleCommandBase, IConsoleCommand
    {
        private const string FLAG_FORMAT = "format";

        private string Format { get; set; }

        public string ValidationMessage { get; private set; }

        public void Init(string[] args, PortalSettings portalSettings, UserInfo userInfo, int activeTabId)
        {
            base.Initialize(args, portalSettings, userInfo, activeTabId);
            System.Text.StringBuilder sbErrors = new System.Text.StringBuilder();

            // Format Flag:
            // ------------------

            // If Flag exists, read it
            // use base class' HasFlag function to determine if flag was passed
            if (HasFlag(FLAG_FORMAT))
            {
                // use base class' Flag() function to retrieve the value.
                // we're passing in "F" to use if the Flag doesn't have a value
                // "F" will do a full format on the date and time.
                Format = Flag(FLAG_FORMAT, "F");
            }
            else
            {
                // no Format flag found - use a default of 'F' for full date formatting
                // Format = "F";
                sbErrors.AppendFormat("You must pass a value in for the '{0}' flag", FLAG_FORMAT);
            }

            ValidationMessage = sbErrors.ToString();
        }

        public bool IsValid()
        {
            return string.IsNullOrEmpty(ValidationMessage);
        }

        public ConsoleResultModel Run()
        {
            return new ConsoleResultModel(System.DateTime.Now.ToString(Format)) { };
        }
    }
}