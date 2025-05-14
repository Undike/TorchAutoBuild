using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorchAutoBuild.Models.Character
{
    public struct MinMaxDamageRange
    {
        public float MinDamage { get; set; }
        public float MaxDamage { get; set; }

        private static readonly Random _random = new Random();

        public MinMaxDamageRange(float minDamage, float maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
        public float GetRandomDamage()
        {
            return (float)(_random.NextDouble() * (MaxDamage - MinDamage) + MinDamage);
        }
        public static MinMaxDamageRange operator +(MinMaxDamageRange a, MinMaxDamageRange b)
            => new(a.MinDamage + b.MinDamage, a.MaxDamage + b.MaxDamage);

        public static MinMaxDamageRange operator -(MinMaxDamageRange a, MinMaxDamageRange b)
            => new(a.MinDamage - b.MinDamage, a.MaxDamage - b.MaxDamage);
    }
}
