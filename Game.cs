using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multigame_Tournament_game_decider
{
    internal class Game
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public Game(string name, string genre)
        {
            Name = name;
            Genre = genre;
        }
    }

}
