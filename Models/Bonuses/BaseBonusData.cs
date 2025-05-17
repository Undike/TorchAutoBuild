using System.Collections.Generic;
using TorchAutoBuild.Models.Character;
namespace TorchAutoBuild.Models.Bonuses
{
    public class BaseBonusData
    {
        public BonusType Type { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public MinMaxDamageRange? DamageRange { get; set; }
        public List<TargetEntity> TargetEntities { get; set; }
        public List<Tags> Tags { get; set; }
        public TargetStat TargetStat { get; set; }
    }
}
