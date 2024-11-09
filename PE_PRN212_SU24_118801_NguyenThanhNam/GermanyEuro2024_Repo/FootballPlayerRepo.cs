using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanyEuro2024_BO;
using Microsoft.EntityFrameworkCore;

namespace GermanyEuro2024_Repo
{
    public class FootballPlayerRepo
    {
        private GermanyEuro2024DbContext context;

        public FootballPlayerRepo()
        {
            context = new GermanyEuro2024DbContext();
        }
        public List<FootballPlayer> GetFootballPlayers()=> context.FootballPlayers.Include("FootballTeam").ToList();
        public FootballPlayer GetFootballPlayer(string id) => context.FootballPlayers.FirstOrDefault(a => a.PlayerId.Equals(id));
        public bool UpdatePlayer(FootballPlayer footballPlayer)
        {
            bool result = false;
            FootballPlayer player = context.FootballPlayers.FirstOrDefault(a => a.PlayerId.Equals(footballPlayer.PlayerId));
            if (player != null)
            {
                player.PlayerName = footballPlayer.PlayerName;
                player.Award = footballPlayer.Award;
                player.Birthday = footballPlayer.Birthday;
                player.Achievements = footballPlayer.Achievements;
                player.FootballTeamId = footballPlayer.FootballTeamId;
                player.OriginCountry = footballPlayer.OriginCountry;
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool AddPlayer(FootballPlayer footballPlayer)
        {
            bool result = false;
            FootballPlayer player = context.FootballPlayers.FirstOrDefault(a => a.PlayerId.Equals(footballPlayer.PlayerId));
            if (player == null)
            {
                context.FootballPlayers.Add(player);
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool RemovePlayer(FootballPlayer footballPlayer)
        {
            bool result = false;
            FootballPlayer player = context.FootballPlayers.FirstOrDefault(a => a.PlayerId.Equals(footballPlayer.PlayerId));
            if (player != null)
            {
                context.FootballPlayers.Remove(player);
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        public List<FootballPlayer> SearchFootballPlayer(string achievement, string playerName)
        {
            return context.FootballPlayers.Where(f => f.Achievements.Contains(achievement.ToLower()) || f.PlayerName.Contains(playerName.ToLower())).ToList();
        }
    }
}
