using Microsoft.Xna.Framework;

namespace Chaos.Models
{
    public class ScreenPartCoordinates
    {
        public ScreenPart ScreenPart;
        public Point UpperLeftCorner;
        public Point LowerRightCorner;

        public ScreenPartCoordinates(ScreenPart screenPart, Point upperLeftCorner, Point lowerRightCorner)
        {
            ScreenPart = screenPart;
            UpperLeftCorner = upperLeftCorner;
            LowerRightCorner = lowerRightCorner;
        }

        public bool Intersects(Point point)
        {
            return point.X >= UpperLeftCorner.X && point.Y >= UpperLeftCorner.Y && point.X <= LowerRightCorner.X && point.Y <= LowerRightCorner.Y;
        }
    }
}