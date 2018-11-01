using System.Collections.Generic;

namespace Chaos.Src.Models
{
    public class Player
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public bool IsHuman { get; set; }
        public bool IsDead { get; set; }
        public int Points { get; set; }

        public List<Spell> Spells;
    }
}