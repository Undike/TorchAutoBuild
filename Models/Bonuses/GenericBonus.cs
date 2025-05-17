using System;
using System.Collections.Generic;

namespace TorchAutoBuild.Models.Bonuses
{
    public class GenericBonus<T> : Bonus
    {
        private readonly T _value;
        public T Value => _value;

        private readonly Action<T> _applyBonus;
        private readonly Action<T> _removeBonus;

        public TargetStat TargetStat { get; }
        public IReadOnlyList<TargetEntity> TargetEntities { get; }

        public GenericBonus(
            string description,
            T value,
            TargetStat targetStat,
            List<TargetEntity> targetEntities,
            List<Tags> tags,
            Action<T> apply,
            Action<T> remove
        ) : base(description, tags)
        {
            _value = value;
            _applyBonus = apply;
            _removeBonus = remove;
            TargetStat = targetStat;
            TargetEntities = targetEntities ?? new();
        }

        public override void ApplyBonus() => _applyBonus?.Invoke(_value);
        public override void RemoveBonus() => _removeBonus?.Invoke(_value);
    }

}
