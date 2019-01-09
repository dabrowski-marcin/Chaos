using System.Collections.Generic;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;

namespace Chaos.Src.Engine.Handlers
{
    public static class StateGlobals
    {
        public static Phase CurrentPhase;
        public static Player CurrentPlayer;
        public static List<Player> Players;
        public static GameTime GameTime;
    }
}