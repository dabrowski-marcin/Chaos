using System.Collections.Generic;

namespace Chaos.Src.Models
{
    public class Creature
    {
        public Player Owner { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public int MaxHitpoints { get; set; }
        public int CurrentHitpoints { get; set; }
        public int InitialHitpoints { get; set; }
        public int MaxAttack { get; set; }
        public int CurrentAttac { get; set; }
        public int InitialAttack { get; set; }
        public int MaxDefense { get; set; }
        public int CurrentDefense { get; set; }
        public int IntialDefense { get; set; }
        public int MaxSpellDefense { get; set; }
        public int CurrentSpellDefense { get; set; }
        public int IntialDSpellDefense { get; set; }
        public int MaxMovement { get; set; }
        public int CurrentMovement { get; set; }
        public int IntialMovement { get; set; }
        public decimal Chance { get; set; }

        public Creature CarriedCreature { get; set; }

        public List<SpecialAttribute> SpecialAttributes { get; set; }
    }
}