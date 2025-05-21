using System.Collections.Generic;
using System.Linq;
using TorchAutoBuild.Models.Talents.CoreNode;
using TorchAutoBuild.Models.Talents.Node;
using TorchAutoBuild.Models.Talents.Tree;

namespace TorchAutoBuild.Factories
{
    public static class TalentTreeFactory
    {
        public static TalentTree CreateTalentTree(TalentTreeData data)
        {
            var nodeDict = new Dictionary<TalentNodePos, TalentNode>();

            foreach (var nodeData in data.TalentNodes)
            {
                var bonuses = nodeData.Bonuses.Select(BonusFactory.Create).ToList();

                nodeDict[nodeData.Pos] = new TalentNode(
                    id: nodeData.Id,
                    talentType: nodeData.TalentType,
                    bonuses: bonuses,
                    pos: nodeData.Pos,
                    requiredTreePoints: nodeData.RequiredTreePoints,
                    maxInvestPoints: nodeData.MaxInvestPoints,
                    prerequisiteTalentPos: nodeData.PrerequisiteTalentPos
                );
            }

            var coreTalents = data.CoreTalentSlots.Select(slot =>
                new CoreTalentSlot(
                    unlockPointsThreshold: slot.UnlockPointsThreshold,
                    coreTalents: slot.CoreTalents.Select(t =>
                        new CoreTalent(
                            id: t.Id,
                            name: t.Name,
                            description: t.Description,
                            bonuses: t.Bonuses.Select(BonusFactory.Create).ToList()
                        )
                    ).ToList()
                )
            ).ToList();

             return new TalentTree(
                id: data.Id,
                treeType: data.TreeType,
                name: data.Name,
                size: data.Size,
                nodeList: nodeDict,
                coreTalentSlots: coreTalents
            );
        }
        public static TalentTree CreateTestTree(string id, string name)
        {
            return new TalentTree(
                id: id,
                treeType: TalentTreeType.ForTesting,
                name: name,
                size: 0,
                nodeList: new Dictionary<TalentNodePos, TalentNode>(),
        coreTalentSlots: new List<CoreTalentSlot>()
            );
        }
    }
}
