using UnityEngine;


namespace VG
{
    public static class Pause
    {
        private static float originTimeScale;
        private static bool originAudioPause;

        private static int pause = 0;
        private static bool pauseWasUsed = false;


        public static void Set(bool active)
        {
            if (!pauseWasUsed && !active) return;
            pauseWasUsed = true;

            if (active)
            {
                pause++;
                if (pause == 1)
                {
                    originTimeScale = Time.timeScale;
                    originAudioPause = AudioListener.pause;

                    AudioListener.pause = true;
                    Time.timeScale = 0f;
                }
            }

            else
            {
                pause--;
                if (pause < 0) pause = 0;

                if (pause == 0)
                {
                    Time.timeScale = originTimeScale;
                    AudioListener.pause = originAudioPause;
                }
            }

        }



    }
}



