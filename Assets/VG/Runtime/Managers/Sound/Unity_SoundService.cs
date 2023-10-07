using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    public class Unity_SoundService : SoundService
    {
        private Dictionary<string, AudioSource> _audioSources;

        public override bool supported => true;



        public override void Initialize()
        {
            foreach (Transform child in transform)
                _audioSources.Add(child.name, child.GetComponent<AudioSource>());


            CompleteInitializing();
        }

        public override void Play(string key_sound, Sound.PlayMode playMode)
        {
            var audioSource = _audioSources[key_sound];


            switch (playMode)
            {
                case Sound.PlayMode.Simple:
                    audioSource.loop = false;
                    audioSource.Play();
                    break;

                case Sound.PlayMode.OneShot:
                    audioSource.PlayOneShot(audioSource.clip);
                    break;

                case Sound.PlayMode.Loop:
                    audioSource.loop = true;
                    audioSource.Play();
                    break;
            }
            
        }

        public override void SetParameter(string key_sound, Dictionary<string, object> parameters)
        {
           
        }

        protected override void OnInitialized() { }



    }

}


