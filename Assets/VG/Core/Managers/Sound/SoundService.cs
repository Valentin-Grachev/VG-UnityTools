using System.Collections.Generic;
using VG.Internal;


namespace VG
{
    public abstract class SoundService : Service
    {
        public abstract void Play(string key_sound, Sound.PlayMode playMode);

        public abstract void SetParameter(string key_sound, Dictionary<string, object> parameters);
    }

}

