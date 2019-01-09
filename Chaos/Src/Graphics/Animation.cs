using System.ServiceModel.Security;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chaos.Graphics
{
    public class Animation : SpriteManager
    {
        public Animation(Texture2D texture)  : base(texture)
        {
            
        }

        private float timeElapsed;
        private float alternateAnimationTime;
        public bool IsLooping = true;
        public int Frames;
        public void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.Milliseconds;
            if (timeElapsed > 250)
            {
                if (FrameIndex < Rectangles.Length - 1)
                {
                    FrameIndex++;
                }
                else if (IsLooping)
                {
                    FrameIndex = 0;
                }

                timeElapsed = 0;
            }
        }
    }
}