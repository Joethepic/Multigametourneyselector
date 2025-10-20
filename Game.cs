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
        public int BossMode { get; set; }
        public Game(string name, string genre, int bossMode = 0)
        {
            Name = name;
            Genre = genre;
            BossMode = bossMode;
        }
    }

}
