using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorchAutoBuild.Models
{
    public readonly struct TalentNodePos
    {
        public int X { get; }
        public int Y { get; }
        public TalentNodePos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
