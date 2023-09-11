using UnityEngine;


namespace VG
{
    public static class Pause
    {
        private static float originTimeScale;
        private static bool originAudioPause;

        private static bool pause = false;



        public static void Set(bool active)
        {
            if (active && pause || !active && !pause) return;


            if (active)
            {
                originTimeScale = Time.timeScale;
                originAudioPause = AudioListener.pause;

                AudioListener.pause = true;
                Time.timeScale = 0f;

                pause = true;
            }

            else
            {
                Time.timeScale = originTimeScale;
                AudioListener.pause = originAudioPause;

                pause = false;
            }

        }



    }
}



