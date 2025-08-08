namespace WebApp.Models
{
    public class WarframeItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Drop> Drops { get; set; }

        // ✅ New: Warframe-specific properties
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Component> Components { get; set; } = new List<Component>();
    }

    public class Drop
    {
        public string Location { get; set; }
        public double? Chance { get; set; } // 0.25 means 25%
        public string Rarity { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }

    public class Component
    {
        public string Name { get; set; }
        public List<Drop> Drops { get; set; } = new List<Drop>();
    }
}