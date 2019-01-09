using System.Collections.Generic;
using System.Linq;
using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Helpers;
using Microsoft.Xna.Framework;
using NLog;

namespace Chaos.Src.Engine.Handlers
{
    public class ButtonsHandler : IButtonsHandler
    {
        private static readonly Logger Log = LoggerController.Buttons;
        private List<ScreenPartCoordinates> _screenParts = new List<ScreenPartCoordinates>();

        public ButtonsHandler()
        {
            _screenParts.Add(new ScreenPartCoordinates(ScreenPart.EndTurnButton, new Point(578, 528), new Point(673, 576)));
        }

        private ScreenPart GetClickedScreenPart(Point positionClicked)
        {
            var screenCoordinates = _screenParts.FirstOrDefault(x => x.Intersects(positionClicked));
            return screenCoordinates?.ScreenPart ?? ScreenPart.Undefined;
        }

        public void Update()
        {
            if (InputHandler.LeftButtonReleased)
            {
                var point = InputHandler.Position;
                var screenPart = GetClickedScreenPart(point.ToPoint());
                // 576x576
                switch (screenPart)
                {
                    case ScreenPart.EndTurnButton:
                        PhaseHandler.ChangeTurn();
                        return;

                    case ScreenPart.Undefined:
                        break;
                }
            }
        }
    }
}