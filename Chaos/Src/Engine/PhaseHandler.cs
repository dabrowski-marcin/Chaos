using Chaos.Src.Engine;
using Chaos.Src.Models;
using System.Collections.Generic;
using System.Diagnostics;
using Chaos.Src.Engine.Handlers;
using Chaos.Src.Helpers;
using NLog;

namespace Chaos.Engine
{
    public static class PhaseHandler
    {
        private static readonly Logger Log = LoggerController.Phase;
        public static Player CurrentPlayer;
        public static Phase GamePhase;

        public static void ChangeTurn()
        {
            if (CurrentPlayer == GetLastActivePlayer())
            {
                ChangePhase();
                CurrentPlayer = ChangeActivePlayer();
                return;
            }

            CurrentPlayer = ChangeActivePlayer();
        }

        private static Player ChangeActivePlayer()
        {
            Player activePlayer;
            var livingPlayers = StateGlobals.Players.FindAll(x => !x.IsDead);

            if (GetLastActivePlayer() == CurrentPlayer)
            {
                activePlayer = livingPlayers[0];
            }
            else
            {
                var nextPlayer = livingPlayers.IndexOf(CurrentPlayer);
                activePlayer = livingPlayers[++nextPlayer];
            }

            Log.Debug($"Changed player to: {activePlayer.Name}.");
            return activePlayer;
        }

        private static Player GetLastActivePlayer()
        {
            var livingPlayers = StateGlobals.Players.FindAll(x => !x.IsDead);
            var player = livingPlayers[livingPlayers.Count - 1];
            return player;
        }

        public static void ChangePhase()
        {
            if (GamePhase == Phase.Independent)
            {
                GamePhase = Phase.SpellPicking;
                Log.Debug($"Changed phase to: {GamePhase}");
                return;
            }

            GamePhase++;
            Log.Debug($"Changed phase to: {GamePhase}");
        }
    }
}