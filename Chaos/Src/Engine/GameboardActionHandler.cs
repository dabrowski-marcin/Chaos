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

        public GameboardActionHandler(IGameboard gameboard)
        {
            this.gameboard = gameboard;
        }

        public void Action(Tile target)
        {
            if (SelectedTile == null)
            {
                if (CheckIfVoidOrInvalidClicked(target))
                {
                    return;
                }

                SelectedTile = target;
                return;
            }

            switch (CheckOutcome(target))
            {
                case GameboardAction.Movement:
                    gameboard.Move(SelectedTile.Position, target.Position);
                    break;
            }

            SelectedTile = null;
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

        public void Update()
        {
            if (InputHandler.Released)
            {
                var point = InputHandler.Position;
                // 576x576
                if (PointBetweenValues(point.ToPoint(), 0, 576))
                {
                    var tile = gameboard.GetTile(point.ToPoint());
                    Action(tile);
                    return;
                }
            }
        }

//        public List<Tile> FindLegalMoves(Tile sourceTile)
//        {
//            var ListOfMoves = new List<Tile>();
//
//            foreach (var tile in gameboard.Tileset)
//            {
//
//            }
//        }


        private bool PointBetweenValues(Point point, int minVal, int maxVal)
        {
            return point.X >= minVal && point.Y >= minVal && point.X <= maxVal && point.Y <= maxVal;

        }
    }
}