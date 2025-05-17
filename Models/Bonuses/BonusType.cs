namespace TorchAutoBuild.Models.Bonuses
{
    public enum BonusType // for Fabric
    {
        IncreaseStat,
        IncreaseAdditionalStat,
        AddFlatStat,
        AddFlatDamage,
        ChangeDamageType,
        IncreaseAdditionalStatWithCooldownCondition, // IncreaseAdditionFireDamageByMainSkill talentBonus in    god_of_might_tree   talent   might_25
        IncreaseAdditionAttackDamageIfUseSkillRecently, 
    }
}
