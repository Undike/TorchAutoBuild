using System.Collections.Generic;

namespace TorchAutoBuild.Models.Bonuses
{
    public abstract class Bonus
    {
        public string Description { get; }
        public IReadOnlyList<Tags> Tags { get; }

        public Bonus(string description, List<Tags>? tags = null)
        {
            if (tags == null)
            {
                tags = new List<Tags> { TorchAutoBuild.Models.Tags.Test };
            }
            Description = description;
            Tags = tags.AsReadOnly();
        }

        public abstract void ApplyBonus();
        public abstract void RemoveBonus();
    }
}