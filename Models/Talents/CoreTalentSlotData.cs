using System.Collections.Generic;

namespace TorchAutoBuild.Models.Talents
{
    public class CoreTalentSlotData
    {
        public int PointsRequired { get; set; }
        public List<CoreTalentData> CoreTalents { get; set; }
    }
}
