using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class WarframeItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Drop> Drops { get; set; }
        
        [JsonPropertyName("imageName")]
        public string ImageName { get; set; }
        
        [JsonPropertyName("levelStats")]
        public List<LevelStat> LevelStats { get; set; }

        [JsonPropertyName("rewards")]
        public List<Reward> Rewards { get; set; }
        
        [JsonPropertyName("vaulted")]
        
        public Boolean Vaulted { get; set; }
    }

    public class Drop
    {
        public string Location { get; set; }
        public double? Chance { get; set; }
        public string Rarity { get; set; }
    }

    public class LevelStat
    {
        public List<string> Stats { get; set; }
    }

    public class Reward
    {
        public string Rarity { get; set; }
        public double Chance { get; set; }

        [JsonPropertyName("item")]
        public RewardItem Item { get; set; }
    }

    public class RewardItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}