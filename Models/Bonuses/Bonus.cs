using System.Collections.Generic;
using TorchAutoBuild.Models;

public abstract class Bonus
{
    public string Description { get; }
    public IReadOnlyList<Tags> Tags { get; }

    public Bonus(string description, List<Tags> tags = null)
    {
        Description = description;
        Tags = tags.AsReadOnly();
    }

    public abstract void ApplyBonus();
    public abstract void RemoveBonus();
}
