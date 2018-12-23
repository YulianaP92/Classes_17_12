using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Artist
    {
        public string Genre;
        public string Name;
        //B5-Player5/10. Constructors
        public Artist()
        {
            Name = "Defaul artists";
            Genre = "Defaul Genre";
        }
        public Artist(string name)
        {
            Name = name;
            Genre = "Defaul Genre";
        }

        public Artist(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }
    }
}
