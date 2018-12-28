using Chaos.Src.Engine;
using Chaos.Src.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chaos.Engine
{
    public static class PhaseHandler
    {
        public static List<Player> ActivePlayers = new List<Player>();
        public static Player CurrentPlayer;
        public static Phase GamePhase;

        public static void ChangeTurn()
        {
            Debug.WriteLine($"Current phase: {GamePhase.ToString()}");
            Debug.WriteLine($"Current player: {CurrentPlayer.Name}");

            if (CurrentPlayer == GetLastActivePlayer())
            {
                ChangePhase();
                CurrentPlayer = ChangeActivePlayer();
                Debug.WriteLine($"Post-change phase: {GamePhase.ToString()}");
                Debug.WriteLine($"Post-change player: {CurrentPlayer.Name}");
                return;
            }

            CurrentPlayer = ChangeActivePlayer();
            Debug.WriteLine($"Post-change player: {CurrentPlayer.Name}");
        }

        private static Player ChangeActivePlayer()
        {

            var livingPlayers = ActivePlayers.FindAll(x => !x.IsDead);

            if (GetLastActivePlayer() == CurrentPlayer)
            {
                return livingPlayers[0];
            }

            var nextPlayer = livingPlayers.IndexOf(CurrentPlayer);

            return livingPlayers[++nextPlayer];
        }

        private static Player GetLastActivePlayer()
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