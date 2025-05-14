using System.Collections.Generic;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents
{
    public class TalentNode
    {
        public string Id { get; }
        public List<Bonus> Bonuses { get; }
        public string Description { get; }
        public TalentNodePos Pos { get; }
        public TalentNode? PrerequisiteTalent { get; }
        public int RequiredTreePoints { get; }
        public int MaxInvestPoints { get; }
        public int CurrentInvestPoints { get; private set; } = 0;

        public TalentNode(
            string id, List<Bonus> bonuses, string description,
            TalentNodePos pos, TalentNode? prerequisiteTalent = null,
            int requiredTreePoints = 0, int maxInvestPoints = 1)
        {
            Id = id;
            Bonuses = bonuses;
            Description = description;
            Pos = pos;
            PrerequisiteTalent = prerequisiteTalent;
            RequiredTreePoints = requiredTreePoints;
            MaxInvestPoints = maxInvestPoints;
        }

        public void InvestPoint()
        {
            if (CurrentInvestPoints < MaxInvestPoints)
            {
                CurrentInvestPoints++;
                foreach (var bonus in Bonuses)
                {
                    bonus.ApplyBonus();
                }
            }
        }
    }
}
