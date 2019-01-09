using Chaos.Src.Helpers;
using Microsoft.Xna.Framework.Audio;
using NLog;

namespace Chaos.Src.Engine
{
    public static class SoundPlayer
    {
        private static readonly Logger Log = LoggerController.Sound;

        public static void PlaySound(SoundType soundType)
        {
            Log.Debug($"Playing {soundType}");
            var sound = StaticManager.ContentManager.Load<SoundEffect>($"Sounds/{soundType.ToString()}");
            sound.Play();
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