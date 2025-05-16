namespace TorchAutoBuild.Models
{
    public enum TargetStat
    {
        // Offensive
        IncreaseAllDamage,
        IncreaseAttackDamage,
        IncreaseSpellDamage,
        IncreaseFireDamage,
        IncreaseColdDamage,
        IncreaseLightningDamage,
        IncreaseErosionDamage,

        IncreaseIgnaiteDamage,
        IncreaseIgniteChance,

        IncreaseAttackSpeed,
        IncreaseCastSpeed,

        IncreaseCriticalStrikeDamage,
        IncreaseMeleeCriticalStrikeDamage,

        IncreaseAttackCriticalStrikeRating,
        IncreaseRangedAttackCriticalStrikeRating,

        IncreaseProjectileSpeed,

        //Skill Area
        IncreaseFireSkillArea,
        IncreaseSkillArea,

        // Defensive
        IncreaseMaxLife,

        IncreaseArmor,

        // Utility
        IncreaseAttackSkillCost,

        IncreaseMovementSpeed,
        // Add as needed
    }
}
