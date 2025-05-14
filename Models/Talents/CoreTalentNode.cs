using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents
{
    class CoreTalentNode : Bonus
    {
        public string Name { get; }

        public CoreTalentNode(string id, string name, string description = "") : base(id, description)
        {
            Name = name;
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
