using Chaos.Src.Models;

namespace Chaos.Engine
{
    public interface IGameboardActionHandler
    {
        Tile SelectedTile { get; set; }
        void Action(Tile targetTile);
        bool CheckIfVoidOrInvalidClicked(Tile clickedTile);
        GameboardAction CheckActionOutcome(Tile clickedTile);
        void Update();
    }
}