using Chaos.Src.Models;

namespace Chaos.Src.Engine
{
    public class CreatureActionHandler
    {
        public static bool Move(Creature creature)
        {
            if (creature.CurrentMovement != 0)
            {
                creature.CurrentMovement--;
                return true;
            }

            return false;
        }
    }
}