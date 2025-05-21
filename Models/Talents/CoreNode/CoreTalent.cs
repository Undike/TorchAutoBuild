using System.Collections.Generic;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents.CoreNode
{
    public class CoreTalent : Bonus // TODO 
    {
        public string Id { get; }
        public string Name { get; }

        public IReadOnlyList<Bonus> Bonuses { get; }

        public CoreTalent(string id, string name, string description, List<Bonus> bonuses ) : base(description)
        {
            Id = id;
            Name = name;
            Bonuses = bonuses.AsReadOnly();
        }

        public override void ApplyBonus()
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveBonus()
        {
            throw new System.NotImplementedException();
        }
    }
}
