﻿using System.Collections.Generic;
using TorchAutoBuild.Models.Bonuses;

namespace TorchAutoBuild.Models.Talents.Node
{
    public class TalentNode
    {
        public string Id { get; }
        public TalentType TalentType { get; }
        public int RequiredTreePoints { get; }
        public int MaxInvestPoints { get; }
        public TalentNodePos Pos { get; }
        public TalentNodePos? PrerequisiteTalentPos { get; }
        public IReadOnlyList<Bonus> Bonuses { get; }

        public TalentNode(
            string id,
            TalentType talentType,
            List<Bonus> bonuses,
            TalentNodePos pos, 
            int requiredTreePoints, 
            int maxInvestPoints,
            TalentNodePos? prerequisiteTalentPos = null)
        {
            Id = id;
            TalentType = talentType;
            Bonuses = bonuses;
            Pos = pos;
            PrerequisiteTalentPos = prerequisiteTalentPos;
            RequiredTreePoints = requiredTreePoints;
            MaxInvestPoints = maxInvestPoints;
        }
    }
}
