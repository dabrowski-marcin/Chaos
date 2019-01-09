using Chaos.Engine;

namespace Chaos.Src.Engine.Handlers
{
    public class GameEventHandler : IGameEventHandler
    {
        private IButtonsHandler buttonsHandler;
        private IGameboardHandler gameboardHandler;
        private ISpellboardHandler spellboardHandler;

        public GameEventHandler(IButtonsHandler buttonsHandler, IGameboardHandler gameboardHandler, ISpellboardHandler spellboardHandler)
        {
            this.buttonsHandler = buttonsHandler;
            this.gameboardHandler = gameboardHandler;
            this.spellboardHandler = spellboardHandler;
        }

        public void Update()
        {
            buttonsHandler.Update();
            gameboardHandler.Update();
            spellboardHandler.Update();
        }
    }
}