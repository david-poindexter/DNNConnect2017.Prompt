using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNNConnect2017.Prompt.Models
{
    public class HerbModel
    {
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Description { get; set; }
        public string[] Songs { get; set; }

        public HerbModel(string name, string scientificName, string description, string[] songs)
        {
            Name = name;
            ScientificName = scientificName;
            Description = description;
            Songs = songs;
        }
    }
}
