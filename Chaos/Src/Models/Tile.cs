using System.Runtime.CompilerServices;
using Chaos.Graphics;
using Chaos.Src.Engine.Handlers;
using Chaos.Src.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NLog;
using NLog.Fluent;

namespace Chaos.Src.Models
{
    public class Tile
    {
        private static readonly Logger Log = LoggerController.Spellboard;

        public readonly Point Size = new Point(48, 48);

        public Point Position { get; set; }

        public Rectangle Rectangle => new Rectangle(Position, Size);

        public SpellAnimationType animationType = SpellAnimationType.None;

        public Texture2D GetTexture()
        {
            Texture2D texture;

            texture = StaticManager.ContentManager.Load<Texture2D>(animationType != SpellAnimationType.None ? $"Effects/{animationType}" : $"Creatures/{Name.Replace(" ", string.Empty)}");

            return texture;
        }

        // public Texture2D Texture => StaticManager.ContentManager.Load<Texture2D>($"Creatures/{Name.Replace(" ", string.Empty)}");

        public Animation Animation => SpriteAnimation();

        private Animation CachedAnimation = null;

        private Animation SpriteAnimation()
        {
            if (CachedAnimation != null)
            {
                return CachedAnimation;
            }

           var animation = new Animation(GetTexture());
           animation.Position = new Vector2(Position.X, Position.Y);
           animation.IsLooping = true;

           CachedAnimation = animation;
           return animation;
        }

        public Creature Occupant { get; set; }

        public bool IsEmpty => Occupant == null;

        public string Name => IsEmpty ? "nothing" : Occupant.Name;

        public void Update(Creature occupant)
        {
            this.Occupant = occupant;
            CachedAnimation = null;
            SpriteAnimation();
        }

        private int elapsed;
        public void Animate(GameTime gameTime)
        {
            if (animationType != SpellAnimationType.None)
            {
                elapsed += gameTime.ElapsedGameTime.Milliseconds;
                if (elapsed < 2000)
                {
                    CachedAnimation = null;
//                    SpriteAnimation();
                    return;
                }

                animationType = SpellAnimationType.None;
            }
        }
    }
}