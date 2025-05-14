using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorchAutoBuild.Models.Bonuses
{
    public class BonusData
    {
        public string Id { get; set; }
        public string Type { get; set; } 
        public string Description { get; set; }
        public float Value { get; set; }
        public string DamageType { get; set; }
        public List<BonusTarget> TargetEntities { get; set; }
    }
}
