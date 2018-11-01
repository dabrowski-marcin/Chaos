using Chaos.Models;
using Chaos.Src.Engine;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;

namespace Chaos.Engine
{
    public class GameboardActionHandler : IGameboardActionHandler
    {
        public Tile SelectedTile { get; set; }
        private IGameboard gameboard;

        private bool _isInMoveMode = false;

        public GameboardActionHandler(IGameboard gameboard)
        {
            this.gameboard = gameboard;
        }

        public void Action(Tile targetTile)
        {
            if (SelectedTile == null)
            {
                if (CheckIfVoidOrInvalidClicked(targetTile))
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
                        gameboard.Move(SelectedTile.Position, targetTile.Position);
                        SoundPlayer.PlaySound(SoundType.Step);
                        SelectedTile = targetTile;

                        return;
                    }
                    break;

            }

            SelectedTile = null;
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

                // 576x576
                if (CheckPartClicked(point.ToPoint(), 0, 576))
                {
                    var tile = gameboard.GetTile(point.ToPoint());
                    Action(tile);
                    return;
                }
            }

            if (InputHandler.LeftButtonReleased)
            {
                SelectedTile = null;
            }
        }

        private Point GameboardBorder = new Point(s);

        private bool CheckPartClicked(Point point, int minVal, int maxVal)
        {
            return point.X >= minVal && point.Y >= minVal && point.X <= maxVal && point.Y <= maxVal;

        }

        private enum ScreenPartClicked
        {
            Gameboard,
            Spellboard,
            InformationButton,
            EndTurnButton
        }
    }
}