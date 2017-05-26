using Dnn.PersonaBar.Prompt.Attributes;
using Dnn.PersonaBar.Prompt.Common;
using Dnn.PersonaBar.Prompt.Interfaces;
using Dnn.PersonaBar.Prompt.Models;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DNNConnect2017.Prompt.Models;
using System.Collections.Generic;

namespace DNNConnect2017.Prompt.Commands
{
    [ConsoleCommand("list-herbs", "dnn-connect", "Returns a list of edible plants", new string[] { })]
    public class ListHerbs : ConsoleCommandBase, IConsoleCommand
    {
        private const string FLAG_NAME = "name";

        private string Name { get; set; }

        public string ValidationMessage { get; private set; }

        public void Init(string[] args, PortalSettings portalSettings, UserInfo userInfo, int activeTabId)
        {
            base.Initialize(args, portalSettings, userInfo, activeTabId);
            System.Text.StringBuilder sbErrors = new System.Text.StringBuilder();

            ValidationMessage = sbErrors.ToString();
        }

        public bool IsValid()
        {
            return string.IsNullOrEmpty(ValidationMessage);
        }

        public ConsoleResultModel Run()
        {
            List<HerbModel> herbs = new List<HerbModel>();
            herbs.Add(new HerbModel("Parsely",
                            "Petroselinum crispum", 
                            "Parsley is a hardy, biennial that is grown and treated like an annual.",
                            new string[] { "Strange Things in My Soup - Allan Sherman",
                                           "Family - Mystikal" }));
            herbs.Add(new HerbModel("Sage",
                            "Salvia officinalis", 
                            "Sage is a shrubby, perennial plant that grows to about 2-3 feet tall.",
                            new string[] { "Scarborough Fair - Simon & Garfunkel",
                                           "Silver on the Sage - Bing Crosby" }));
            herbs.Add(new HerbModel("Rosemary",
                            "Rosemarinus officinalis",
                            "Rosemary is a perennial evergreen shrub in warmer growing zones (zone 8 and above).",
                            new string[] { "Rosemary Rose - Kinks",
                                           "Stealing Rosemary - Bangles" }));
            herbs.Add(new HerbModel("Thyme",
                            "Thymus vulgaris",
                            "Thyme is a low growing (6-12 inches tall) to almost prostrate, wiry stemmed perennial.",
                            new string[] { "Wild Mountain Thyme - The Chieftains",
                                           "Purple Heather - Rod Steward" }));
            herbs.Add(new HerbModel("Marijuana",
                            "Cannabis",
                            "Good stuff - medical purposes only of course!",
                            new string[] { "The Chronic - Dr Dre",
                                           "Purple Haze - Jimi Hendrix" }));

            if (HasFlag(FLAG_NAME))
            {
                string searchTerm = Flag(FLAG_NAME, "");
                // try to find the herb in our list
                HerbModel herb = herbs.Find( x => x.Name.Contains(searchTerm) || x.ScientificName.Contains(searchTerm));
                List<HerbModel> results = new List<HerbModel>();
                results.Add(herb);
                return new ConsoleResultModel() { data = results };
            }
            else
            {
                return new ConsoleResultModel(herbs.Count + " herbs found")
                {
                    data = herbs,
                    fieldOrder = new string[] { "ScientificName", "Name", "Description", "Songs" }
                };
            }
        }
    }
}
