using System;

namespace Chaos.Src.Models
{
    [Flags]
    public enum SpecialAttribute
    {
        None = 0,
        IsImmovable = 1,
        IsUndead = 2,
        IsFlying = 4, 
        IsRanged = 8,
        IsSpecial = 16,
        CanAttackUndead = 32,
        CanCarry = 64,
        Replicates = 128,
        DragonBreath = 256,
    }
}