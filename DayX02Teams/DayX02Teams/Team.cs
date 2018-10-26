using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayX02Teams
{
    class Team
    {
        private string name;
        private int gamesWon;
        private int gamesLost;
        private int goalsShot;

        public Team(string name, int gamesWon, int gamesLost, int goalsShot)
        {
            Name = name;
            GamesWon = gamesWon;
            GamesLost = gamesLost;
            GoalsShot = goalsShot;
        }

        public string Name { get => name; set => name = value; }
        public int GamesWon { get => gamesWon; set => gamesWon = value; }
        public int GamesLost { get => gamesLost; set => gamesLost = value; }
        public int GoalsShot { get => goalsShot; set => goalsShot = value; }

     
    }
}
