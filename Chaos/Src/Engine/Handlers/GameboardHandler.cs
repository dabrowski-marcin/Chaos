using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chaos.Src.Helpers;
using NLog;

namespace Chaos.Src.Engine.Handlers
{
    public class GameboardHandler : IGameboardHandler
    {
        private static readonly Logger Log = LoggerController.Gameboard;

        public Tile SelectedTile { get; set; }
        private readonly IGameboard gameboard;
        private readonly ISpellboard spellboard;        

        public GameboardHandler(IGameboard gameboard, ISpellboard spellboard)
        {
            this.gameboard = gameboard;
            this.spellboard = spellboard;
        }

        private bool IsCurrentPlayerOwner(Tile targetTile)
        {
            return targetTile.Occupant != null && targetTile.Occupant.Owner == PhaseHandler.CurrentPlayer;
        }
        public void MovementAction(Tile targetTile)
        {
            if (PhaseHandler.GamePhase == Phase.Movement)
            {
                if (SelectedTile == null)
                {
                    if (CheckIfVoidOrInvalidClicked(targetTile) || !IsCurrentPlayerOwner(targetTile))
                    {
                        return;
                    }

                    SoundPlayer.PlaySound(SoundType.Click);
                    SelectedTile = targetTile;
                    return;
                }

                switch (CheckActionOutcome(targetTile))
                {
                    case GameboardAction.Movement:
                        if (CreatureActionHandler.Move(SelectedTile.Occupant))
                        {
                            Log.Debug($"Moving {SelectedTile.Occupant.Name} from tile POS: {SelectedTile.Position} to tile POS: {targetTile.Position}");
                            gameboard.Move(SelectedTile.Position, targetTile.Position);
                            SoundPlayer.PlaySound(SoundType.Step);
                            SelectedTile = targetTile;

                            return;
                        }

                        break;
                }

              //  SelectedTile = null;
            }
        }

        public bool CheckIfVoidOrInvalidClicked(Tile clickedTile)
        {
            return (clickedTile == null || clickedTile.IsEmpty);
        }

        public GameboardAction CheckActionOutcome(Tile clickedTile)
        {
            var result = GameboardAction.None;

            if (clickedTile.IsEmpty)
            {
                result = GameboardAction.Movement;
            }

            return result;
        }


        public void Update()
        {
            if (InputHandler.LeftButtonReleased)
            {
                var point = InputHandler.Position;
                var screenPart = ScreenManager.GetClickedScreenPart(point.ToPoint());
                // 576x576
                switch (screenPart)
                {
                    case ScreenPart.Gameboard:
                    {
                        var tile = gameboard.GetTile(point.ToPoint());
                        MovementAction(tile);
                        return;
                    }

                    case ScreenPart.Spellboard:
                        break;

                    case ScreenPart.Undefined:
                        break;
                }
            }

            if (InputHandler.RightButtonReleased)
            {
                SelectedTile = null;
            }
        }

        private bool CheckPartClicked(Point point, int minVal, int maxVal)
        {
            return point.X >= minVal && point.Y >= minVal && point.X <= maxVal && point.Y <= maxVal;

        }
    }
}