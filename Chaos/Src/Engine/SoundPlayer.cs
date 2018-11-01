using Chaos.Src.Helpers;
using Microsoft.Xna.Framework.Audio;

namespace Chaos.Src.Engine
{
    public static class SoundPlayer
    {
        public static void PlaySound(SoundType sound)
        {
            var snd = StaticManager.ContentManager.Load<SoundEffect>(sound.ToString());
            snd.Play();
        }
    }

    public enum SoundType
    {
        Name,
        Click,
        Step,
        Combat,
        InvalidTarget,
        ArrowFlight,
        BoltFlight,
        Fire,
        Lightning,
        Cancel
    }
}