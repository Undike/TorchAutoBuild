using System.Collections.Generic;
using TorchAutoBuild.Models.Talents.Tree;

namespace TorchAutoBuild.Models.Talents.God
{
    public class God
    {
        public string Id { get; }
        public string Name { get; }
        public IReadOnlyList<TalentTree> TalentTrees { get; }

        public God(string id, string name, List<TalentTree> talentTrees)
        {
            Id = id;
            Name = name;
            TalentTrees = talentTrees.AsReadOnly();
        }
    }
}
