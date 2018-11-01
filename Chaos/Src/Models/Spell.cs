namespace Chaos.Src.Models
{
    public class Spell
    {
        public int Id;
        public string Name;
        public int Range;
        public bool RequiresLoS;
        public decimal Chance;
        public decimal EffectChance;
        public SpellType Type;
        public SpellAnimationType SpellAnimationType;
    }

    public enum SpellType
    {
        Summoning,
        TargetedOffensive,
        TargetedDefensive,
        SpecialSubversion,
        Self
    }

    public enum SpellAnimationType
    {
        Bolt,
        Lightning,
        Swirl,
        Graining,
        Arrow,
        Bubble
    }
}