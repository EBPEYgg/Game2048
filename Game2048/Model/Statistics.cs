using Game2048.Model.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace Game2048.Model
{
    public class Statistics
    {
        public static ObservableCollection<Player> Players
        {
            get => StatisticsSerializer.LoadPlayer();
        }

        public static void Add(string name, string score)
        {
            Player player = new Player(name, score);
            ObservableCollection<Player> players = StatisticsSerializer.LoadPlayer();

            if (players.Any(p => p.Name == name))
            {
                Player writedPlayer = players.FirstOrDefault(p => p.Name == name);
                if (int.Parse(writedPlayer.Score) < int.Parse(player.Score))
                {
                    writedPlayer.Score = player.Score;
                }
            }
            else
            {
                players.Add(player);
            }
            StatisticsSerializer.SavePlayer(players);
        }
    }
}