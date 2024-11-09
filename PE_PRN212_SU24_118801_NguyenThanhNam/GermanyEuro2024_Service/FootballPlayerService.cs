using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024_BO;
using GermanyEuro2024_Repo;

namespace GermanyEuro2024_Service
{
    public class FootballPlayerService
    {
        private FootballPlayerRepo repo = new();

        public List<FootballPlayer> GetFootballPlayers() => repo.GetFootballPlayers();
        public FootballPlayer GetFootballPlayer(string id) => repo.GetFootballPlayer(id);
        public bool AddPlayer(FootballPlayer footballPlayer) => repo.AddPlayer(footballPlayer);
        public bool RemovePlayer(FootballPlayer footballPlayer) => repo.RemovePlayer(footballPlayer);
        public bool UpdatePlayer(FootballPlayer footballPlayer) => repo.UpdatePlayer(footballPlayer);
        public List<FootballPlayer> SearchFootballPlayer(string achievement, string playerName) => repo.SearchFootballPlayer(achievement, playerName);
    }
}
