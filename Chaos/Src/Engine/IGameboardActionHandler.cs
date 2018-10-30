using Chaos.Src.Models;

namespace Chaos.Engine
{
    public interface IGameboardActionHandler
    {
        Tile SelectedTile { get; set; }
        void Action(Tile target);
        bool CheckIfVoidOrInvalidClicked(Tile clickedTile);
        GameboardAction CheckOutcome(Tile clickedTile);
        void Update();
    }
}