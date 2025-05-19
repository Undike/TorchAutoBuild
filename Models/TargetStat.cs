namespace TorchAutoBuild.Models
{
    public enum TargetStat
    {
        // Offensive
        IncreaseDamage,
        IncreaseAttackDamage,
        IncreaseSpellDamage,
        IncreaseFireDamage,
        IncreaseColdDamage,
        IncreaseLightningDamage,
        IncreaseErosionDamage,
        IncreaseIgniteDamage,
        IncreaseIgniteChance,

        IncreaseAttackSpeed,
        IncreaseCastSpeed,

        IncreaseCriticalStrikeDamage,
        IncreaseMeleeCriticalStrikeDamage,

        IncreaseAttackCriticalStrikeRating,
        IncreaseRangedAttackCriticalStrikeRating,

        IncreaseProjectileSpeed,

        // Skill
        IncreaseAttackSkillLevel,

        //Skill Area
        IncreaseFireSkillArea,
        IncreaseSkillArea,

        // Defensive
        IncreaseMaxLife,
        IncreaseLifeRegain,
        IncreaseArmor,

        AddFireResistance,

        // Utility
        IncreaseAttackSkillCost,
        WarcryCooldownRecoverySpeed,

        // convert damage types
        ConvertPhysicalToFireDamage,


        IncreaseMovementSpeed,

        // With Condition
        IncreaseAdditionFireDamageByMainSkill,
        IncreaseAdditionAttackDamageIfUseSkillRecently,

        // Add as needed

        // Add Flat Stats
        AddStrength,
    }
}
