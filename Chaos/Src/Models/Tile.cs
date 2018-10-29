using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chaos.Src.Models
{
    public class Tile
    {
        public readonly Point Size = new Point(48, 48);
        public Point Position { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Position, Size); }
        }

        public Texture2D Texture { get; set; }
        public Creature Occupant { get; set; }

        public bool IsEmpty
        {
            get { return Occupant == null; }
        }
    }
}