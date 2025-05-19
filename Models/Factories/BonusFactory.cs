using System;
using System.Collections.Generic;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Factories
{
    public static class BonusFactory
    {
        public static Bonus Create(BaseBonusData data)
        {
            return data.Type switch
            {
                BonusType.IncreaseStat => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                BonusType.IncreaseAdditionalStat => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                BonusType.AddFlatStat => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                BonusType.AddFlatDamage => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                BonusType.ChangeDamageType => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                BonusType.IncreaseAdditionalStatWithCooldownCondition => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                BonusType.IncreaseAdditionAttackDamageIfUseSkillRecently => new GenericBonus<float>(
                    description: FormatDescription(data.Description, data),
                    tags: data.Tags,
                    value: data.Value,
                    apply: target => {/* TODO */},
                    remove: target => {/* TODO */},
                    targetStat: data.TargetStat,
                    targetEntities: data.TargetEntities
                ),
                _ => throw new NotSupportedException($"Bonus type {data.Type} is not supported.")
            };
        }

        private static string FormatDescription(string template, BaseBonusData data)
        {
            if (string.IsNullOrWhiteSpace(template)) return "";
            return template
                .Replace("{Value}", data.Value.ToString())
                .Replace("{TargetStat}", data.TargetStat.ToString() ?? "");
        }
    }
}