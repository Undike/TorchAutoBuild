using System.Collections.Generic;

namespace TorchAutoBuild.Models.Talents
{
    public class GodData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<TalentTreeData> TalentTrees { get; set; }
    }
}
