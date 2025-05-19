using System.Collections.Generic;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents.CoreNode
{
    public class CoreTalentData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BaseBonusData> Bonuses { get; set; }
        public List<Tags> Tags { get; set; }
    }
}
