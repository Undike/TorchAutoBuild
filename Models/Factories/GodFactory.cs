using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TorchAutoBuild.Models.Talents.God;
using TorchAutoBuild.Models.Talents.Tree;

namespace TorchAutoBuild.Factories
{
    public static class GodFactory
    {
        public static God LoadGod(string godJsonPath)
        {
            var godDataJson = File.ReadAllText(godJsonPath);
            var godData = JsonConvert.DeserializeObject<GodData>(godDataJson);

            var talentTrees = new List<TalentTree>();

            foreach (var treeData in godData.TalentTrees)
            {

                if (treeData != null)
                {
                    var talentTree = TalentTreeFactory.CreateTalentTree(treeData);
                    talentTrees.Add(talentTree);
                }
                else
                {
                    // Temporary fallback for missing trees, only for testing how it works
                    talentTrees.Add(TalentTreeFactory.CreateTestTree(treeData.Id, treeData.Name));
                }
            }

            return new God(godData.Id, godData.Name, talentTrees);
        }
        public static God CreateTestGod(string godId, string godName)
        {
            var testTrees = new List<TalentTree>();

            // Добавим 4 заглушки-древа с уникальными Id
            for (int i = 0; i < 4; i++)
            {
                var treeId = $"{godId}_tree{i + 1}";
                var treeName = $"Tree {i + 1}";
                var testTree = TalentTreeFactory.CreateTestTree(treeId, treeName);
                testTrees.Add(testTree);
            }

            return new God(godId, godName, testTrees);
        }
    }
}
