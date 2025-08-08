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
    }

    public class Drop
    {
        public string Location { get; set; }
        public double? Chance { get; set; } // 0.25 means 25%
        public string Rarity { get; set; }
    }
}