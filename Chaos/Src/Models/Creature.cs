using System.Collections.Generic;

namespace Chaos.Src.Models
{
    public class Creature
    {
        public Player Owner { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public int InitialHitpoints { get; set; }
        public int InitialAttack { get; set; }
        public int InitialDefense { get; set; }
        public int InitialSpellDefense { get; set; }
        public int InitialMovement { get; set; }
        public int InitialRangedAttack { get; set; }
        public int InitialRange { get; set; }

        public int CurrentHitpoints { get; set; }
        public int CurrentAttack { get; set; }
        public int CurrentDefense { get; set; }
        public int CurrentSpellDefense { get; set; }
        public int CurrentMovement { get; set; }
        public int CurrentRangedAttack { get; set; }
        public int CurrentRange { get; set; }

        public int MaxHitpoints { get; set; }
        public int MaxAttack { get; set; }
        public int MaxDefense { get; set; }
        public int MaxSpellDefense { get; set; }
        public int MaxMovement { get; set; }
        public int MaxRangedAttack { get; set; }
        public int MaxRange { get; set; }

        public Creature()
        {
            CurrentHitpoints = InitialHitpoints;
            MaxHitpoints = InitialHitpoints;

            CurrentMovement = InitialMovement;
            MaxMovement = InitialMovement;

            CurrentAttack = InitialAttack;
            MaxAttack = InitialAttack;

            CurrentDefense = 0;
            MaxDefense = 0;
            InitialDefense = 0;

            CurrentSpellDefense = InitialSpellDefense;
            MaxSpellDefense = InitialSpellDefense;

            CurrentRange = InitialRange;
            MaxRange = InitialRange;
            CurrentRangedAttack = InitialRangedAttack;
            MaxRangedAttack = InitialRangedAttack;
        }

        public Creature CarriedCreature { get; set; }
        public SpecialAttribute SpecialAttributes { get; set; }

    }

    public class CreatureIdTracker
    {
        private static int Id = 0;
        public static int GiveId = ++Id;
    }
}