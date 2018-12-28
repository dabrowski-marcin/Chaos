using Chaos.Engine;

namespace Chaos.Src.Engine.Handlers
{
    public class GameEventHandler : IGameEventHandler
    {
        private IButtonsHandler buttonsHandler;
        private IGameboardHandler gameboardHandler;

        public GameEventHandler(IButtonsHandler buttonsHandler, IGameboardHandler gameboardHandler)
        {
            this.buttonsHandler = buttonsHandler;
            this.gameboardHandler = gameboardHandler;
        }

        public void Update()
        {
            buttonsHandler.Update();
            gameboardHandler.Update();
        }
    }
}