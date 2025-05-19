using System.Collections.Generic;

namespace TorchAutoBuild.Models.Talents.CoreNode
{
    public class CoreTalentSlotData
    {
        public int UnlockPointsThreshold { get; set; }
        public List<CoreTalentData> CoreTalents { get; set; }
    }
}
