using System.Collections.Generic;
using System.Linq;
using Chaos.Models;
using Microsoft.Xna.Framework;

namespace Chaos.Src.Engine.Handlers
{
    public static class ScreenManager
    {
        public static readonly List<ScreenPartCoordinates> ScreenParts = new List<ScreenPartCoordinates>();

        static ScreenManager()
        {
            ScreenParts.Add(new ScreenPartCoordinates(ScreenPart.Gameboard, new Point(0, 0), new Point(575, 575)));
            ScreenParts.Add(new ScreenPartCoordinates(ScreenPart.Spellboard, new Point(578, 0), new Point(672, 528)));
        }

        public static ScreenPart GetClickedScreenPart(Point positionClicked)
        {
            var screenCoordinates = ScreenManager.ScreenParts.FirstOrDefault(x => x.Intersects(positionClicked));
            return screenCoordinates?.ScreenPart ?? ScreenPart.Undefined;
        }
    }
}