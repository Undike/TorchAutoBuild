using System.Collections.Generic;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents
{
    public class TalentNodeData
    {
        public string Id { get; set; }
        public TalentType TalentType { get; set; }
        public TalentNodePos Pos { get; set; }
        public int RequiredTreePoints { get; set; }
        public int MaxInvestPoints { get; set; }
        public string PrerequisiteTalent { get; set; }
        public List<BaseBonusData> Bonuses { get; set; }
    }
}
