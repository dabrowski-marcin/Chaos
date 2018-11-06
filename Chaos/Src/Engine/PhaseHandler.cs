using System.Collections.Generic;
using System.Linq;
using Chaos.Src.Engine;
using Chaos.Src.Models;

namespace Chaos.Engine
{
    public static class PhaseHandler
    {
        public static List<Player> ActivePlayers = new List<Player>();
        public static Player CurrentPlayer;
        public static Phase GamePhase;

        public void ChangeActivePlayer()
        {
            
        }

        public static Player GetLastActivePlayer()
        {
            var livingPlayers = ActivePlayers.FindAll(x => !x.IsDead);
            return livingPlayers[livingPlayers.Count - 1];
        }

        public static void ChangePhase()
        {
            if (GamePhase == Phase.Independent)
            {
                GamePhase = Phase.Spellcasting;
                return;
            }

            GamePhase++;
        }
    }
}