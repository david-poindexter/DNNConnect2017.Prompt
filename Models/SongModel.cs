using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNNConnect2017.Prompt.Models
{
    public class SongModel
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string[] Genres { get; set; }

        public SongModel(string name, string artist, string[] genres)
        {
            Name = name;
            Artist = artist;
            Genres = genres;
        }
    }
}
