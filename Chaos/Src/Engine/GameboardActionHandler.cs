using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Chaos.Models;
using Chaos.Src.Models;

namespace Chaos.Engine
{
    public class GameboardActionHandler
    {
        public Tile SourceTile { get; set; }
        public Tile TargetTile { get; set; }

        private IGameboard gameboard;

        public GameboardActionHandler(IGameboard gameboard)
        {
            this.gameboard = gameboard;
        }

        public void Action(Tile clickedTile)
        {
            if (SourceTile == null)
            {
                if (CheckIfVoidOrInvalidClicked(clickedTile))
                {
                    return;
                }

                SourceTile = clickedTile;
                return;
            }

            switch (CheckOutcome(clickedTile))
            {
                case GameboardAction.Movement:
                    gameboard.Move(SourceTile.Position, clickedTile.Position);
                    break;
            }

            SourceTile = null;
        }

        public bool CheckIfVoidOrInvalidClicked(Tile clickedTile)
        {
            return (clickedTile == null || clickedTile.IsEmpty);
        }

        public GameboardAction CheckOutcome(Tile clickedTile)
        {
            var result = GameboardAction.None;

            if (clickedTile.IsEmpty)
            {
                result = GameboardAction.Movement;
            }

            return result;
        }

        private void Clear()
        {
            SourceTile = null;
           // TargetTile = null;
        }
    }
}