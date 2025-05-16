using System.Collections.Generic;
using TorchAutoBuild.Models.Talents;

public class CoreTalentSlot
{
    public int PointsRequired { get; }
    public IReadOnlyList<CoreTalent> CoreTalents { get; }

    public CoreTalentSlot(int pointsRequired, List<CoreTalent> coreTalents)
    {
        PointsRequired = pointsRequired;
        CoreTalents = coreTalents.AsReadOnly();
    }
}
