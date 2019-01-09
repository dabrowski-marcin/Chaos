using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chaos.Graphics
{
    public abstract class SpriteManager
    {
        protected Texture2D Texture;
        public Vector2 Position = Vector2.Zero;
        public  Color Color = Color.Wheat;
        public Vector2 Origin;
        public float Rotation = 0f;
        public float Scale = 1f;
        public SpriteEffects SpriteEffects;
        protected Rectangle[] Rectangles;
        protected int FrameIndex = 0;

        public SpriteManager()
        {
            
        }

        public SpriteManager(Texture2D Texture)
        {
            this.Texture = Texture;
            int frames = Texture.Width / 48;
            int width = Texture.Width / frames;
            Rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle(i * width, 0, width, Texture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Rectangles[FrameIndex], Color, Rotation, Origin, Scale, SpriteEffects, 0f);
            spriteBatch.End();
        }
    }
}