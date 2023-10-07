using System.Collections.Generic;
using VG.Internal;



namespace VG
{
    public class Sound : Manager
    {
        public enum PlayMode { Simple, OneShot, Loop }


        private static Sound instance;
        private static SoundService service => instance.supportedService as SoundService;

        protected override string managerName => "VG Sound";


        protected override void OnInitialized()
        {
            instance = this;
            Log(Core.Message.Initialized(managerName));
        }


        public static void Play(string key_sound, PlayMode playMode)
        {
            service.Play(key_sound, playMode);
            instance.Log($"Play {key_sound}, mode: {playMode}");
        }

        public static void SetParameter(string key_sound, Dictionary<string, object> parameters)
        {
            service.SetParameter(key_sound, parameters);
            instance.Log("Set parameter " + key_sound);
        }

    }

}
