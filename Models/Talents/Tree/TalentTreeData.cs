using System.Collections.Generic;
using TorchAutoBuild.Models.Talents.CoreNode;
using TorchAutoBuild.Models.Talents.Node;

namespace TorchAutoBuild.Models.Talents.Tree
{
    public class TalentTreeData
    {
        public string Id { get; set; }
        public TalentTreeType TreeType { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public List<CoreTalentSlotData> CoreTalentSlots { get; set; }
        public List<TalentNodeData> TalentNodes { get; set; }
    }
}
