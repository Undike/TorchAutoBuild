using System.Collections.Generic;
using System.Linq;
using TorchAutoBuild.Models.Talents.CoreNode;
using TorchAutoBuild.Models.Talents.Node;

namespace TorchAutoBuild.Models.Talents.Tree
{
    public class TalentTree
    {
        public string Id { get; }
        public TalentTreeType TreeType { get; }
        public string Name { get; }
        public int Size { get; }

        private readonly Dictionary<TalentNodePos, TalentNode> _nodeList;
        private readonly Dictionary<string, TalentNode> _nodesById;
        private readonly HashSet<Tags> _tags;

        public IReadOnlyCollection<Tags> Tags => _tags;
        public IReadOnlyList<TalentNode> Nodes => _nodesById.Values.ToList().AsReadOnly();
        public IReadOnlyList<CoreTalentSlot> CoreTalentSlots { get; }

        public TalentTree(
            string id,
            TalentTreeType treeType,
            string name,
            int size,
            Dictionary<TalentNodePos, TalentNode> nodeList,
            List<CoreTalentSlot> coreTalentSlots)
        {
            Id = id;
            TreeType = treeType;
            Name = name;
            Size = size;

            _nodeList = nodeList;
            _nodesById = nodeList.Values.ToDictionary(n => n.Id, n => n);

            _tags = new HashSet<Tags>();
            foreach (var node in _nodeList.Values)
            {
                foreach (var bonus in node.Bonuses)
                {
                    foreach (var tag in bonus.Tags)
                    {
                        _tags.Add(tag);
                    }
                }
            }

            CoreTalentSlots = coreTalentSlots.AsReadOnly();
        }

        public TalentNode GetNodeById(string id)
    => _nodesById.TryGetValue(id, out var node) ? node : null;

        public TalentNode GetNodeByPos(TalentNodePos pos)
            => _nodeList.TryGetValue(pos, out var node) ? node : null;
    }
}
