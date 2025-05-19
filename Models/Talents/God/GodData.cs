using System.Collections.Generic;
using TorchAutoBuild.Models.Talents.Tree;

namespace TorchAutoBuild.Models.Talents.God
{
    public class GodData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<TalentTreeData> TalentTrees { get; set; }
    }
}
