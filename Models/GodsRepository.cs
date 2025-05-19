using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TorchAutoBuild.Factories;
using TorchAutoBuild.Models.Talents.God;
using TorchAutoBuild.Models.Talents.Tree;

namespace TorchAutoBuild.Models
{
    public static class GodsRepository
    {
        private static List<God> _gods;

        public static IReadOnlyList<God> Gods => _gods;

        static GodsRepository()
        {
            LoadGods();
        }

        private static void LoadGods()
        {
            var gods = new List<God>();

            // Путь к папке с данными
            var exeDir = AppContext.BaseDirectory;
            var projectRoot = Path.GetFullPath(Path.Combine(exeDir, @"..\..\..\"));
            var godsFolder = Path.Combine(projectRoot, "Data", "Gods");

            // Считаем, что в папке с богами лежат json-файлы с описанием каждого бога
            if (Directory.Exists(godsFolder))
            {
                foreach (var godFile in Directory.GetFiles(godsFolder, "*.json"))
                {
                    var god = GodFactory.LoadGod(godFile);
                    gods.Add(god);
                }
            }

            _gods = gods;
        }

        public static God? GetGodById(string id) => _gods.Find(g => g.Id == id);

        public static TalentTree? GetTalentTree(string godId, string treeId)
        {
            var god = GetGodById(godId);
            return god?.TalentTrees.FirstOrDefault(t => t.Id == treeId);
        }
    }
}