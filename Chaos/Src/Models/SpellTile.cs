using Chaos.Src.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chaos.Src.Models
{
    public class SpellTile
    {
        public readonly Point Size = new Point(48, 48);
        public Point Position { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(Position, Size); }
        }

        public Texture2D Texture
        {
            get { return StaticManager.ContentManager.Load<Texture2D>($"Spells/{Name.Replace(" ", string.Empty)}"); }
        }

        public Spell Spell { get; set; }

        public bool IsEmpty
        {
            get { return Spell == null; }
        }

        public string Name
        {
            get { return IsEmpty ? "nothing" : Spell.Name; }
        }
    }
}