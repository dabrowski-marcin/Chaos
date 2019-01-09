using System.Dynamic;
using System.Linq;
using Chaos.Engine;
using Chaos.Src.Models;

namespace Chaos.Src.Engine.Handlers
{
    public class Spellcasting
    {
        public static Creature Creation(Spell spell)
        {
            var creature = CreaturesGenerator.CreatureTemplates.FirstOrDefault(c => c.Name == spell.Name);
            creature.Id = CreatureIdTracker.GiveId;
            creature.Owner = PhaseHandler.CurrentPlayer;
            return creature;
        }
    }
}