using System;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents
{
    class IncreaseBonus : Bonus
    {
        private readonly float _value;
        private readonly Action<float> _applyBonus;
        private readonly Action<float> _removeBonus;
        public TargetStat DamageType { get;}

        public IncreaseBonus(string id, string description, float value, Action<float> applyBonus, Action<float> removeBonus, TargetStat damageType) : base(id, description)
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
