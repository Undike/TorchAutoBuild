using System;
using TorchAutoBuild.Models.Bonuses;
using TorchAutoBuild.Models.Character;

namespace TorchAutoBuild.Models.Talents
{
    class AddFlatDamage : Bonus
    {
        private readonly MinMaxDamageRange _value;
        private readonly Action<MinMaxDamageRange> _applyBonus;
        private readonly Action<MinMaxDamageRange> _removeBonus;
        public TargetStat DamageType { get; }

        public AddFlatDamage(
            string id, string description, MinMaxDamageRange value,
            Action<MinMaxDamageRange> applyBonus, Action<MinMaxDamageRange> removeBonus, TargetStat damageType) : base(id, description)
        {
            _value = value;
            _applyBonus = applyBonus;
            _removeBonus = removeBonus;
            DamageType = damageType;
        }

        public override void ApplyBonus() => _applyBonus(_value);

        public override void RemoveBonus() => _removeBonus(_value);
    }
}
