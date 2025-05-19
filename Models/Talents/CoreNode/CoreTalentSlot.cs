using System.Collections.Generic;

namespace TorchAutoBuild.Models.Talents.CoreNode
{
    public class CoreTalentSlot
    {
        public int UnlockPointsThreshold { get; }
        public IReadOnlyList<CoreTalent> CoreTalents { get; }

        public CoreTalentSlot(int unlockPointsThreshold, List<CoreTalent> coreTalents)
        {
            UnlockPointsThreshold = unlockPointsThreshold;
            CoreTalents = coreTalents.AsReadOnly();
        }
    }
}
