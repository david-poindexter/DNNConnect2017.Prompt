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
    [ConsoleCommand("list-songs", "dnn-connect", "Returns a list of songs", new string[] { })]
    public class ListSongs : ConsoleCommandBase, IConsoleCommand
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
            List<SongModel> songs = new List<SongModel>();
            songs.Add(new SongModel("DNN Yeti",
                            "Ron Miles", 
                            new string[] { "Folk",
                                           "DNN" }));
            songs.Add(new SongModel("Back In Black",
                            "AC/DC", 
                            new string[] { "Hard Rock",
                                           "Classic Rock" }));
			songs.Add(new SongModel("Break Free",
							"Ariana Grande",
							new string[] { "Pop" }));

			if (HasFlag(FLAG_NAME))
            {
                string searchTerm = Flag(FLAG_NAME, "");
                // try to find the herb in our list
                SongModel song = songs.Find( x => x.Name.Contains(searchTerm) || x.Artist.Contains(searchTerm));
                List<SongModel> results = new List<SongModel>();
                results.Add(song);
                return new ConsoleResultModel() { data = results };
            }
            else
            {
                return new ConsoleResultModel(songs.Count + " songs found")
                {
                    data = songs,
                    fieldOrder = new string[] { "Name", "Artist" }
                };
            }
        }
    }
}
