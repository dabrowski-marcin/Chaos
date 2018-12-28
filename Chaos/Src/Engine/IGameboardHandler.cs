using Chaos.Src.Models;

namespace Chaos.Engine
{
    public interface IGameboardHandler
    {
        Tile SelectedTile { get; set; }
        void MovementAction(Tile targetTile);
        bool CheckIfVoidOrInvalidClicked(Tile clickedTile);
        GameboardAction CheckActionOutcome(Tile clickedTile);
        void Update();
    }
}