using System.Collections.Generic;

namespace TorchAutoBuild.Models.Bonuses
{
    public abstract class Bonus
    {
        public string Id { get; }
        public string Description { get; }

        public Bonus(string id, string description = "")
        {
            Id = id;
            Description = description;
        }

        public abstract void ApplyBonus();
        public abstract void RemoveBonus();
    }
}
