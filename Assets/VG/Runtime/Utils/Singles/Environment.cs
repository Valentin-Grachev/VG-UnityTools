using UnityEngine;
using UnityEngine.Events;

namespace VG
{
    public class Environment : Initializable
    {


        public enum Platform { Android, WebGL, Desctop, iOS }
        public enum GameStore { GooglePlay, YandexGames, CrazyGames }
        public enum Skin { Original }


        [SerializeField] private GameStore _gameStore;
        [SerializeField] private Skin _skin;

        public static GameStore gameStore { get; private set; }
        public static Skin skin { get; private set; }


        public static bool editor
        {
            get
            {
                #if UNITY_EDITOR
                    return true;
                #else
                    return false;
                #endif
            }
        }

        public static Platform platform 
        { 
            get
            {
                #if UNITY_WEBGL
                    return Platform.WebGL;
                #endif
                
                #if UNITY_ANDROID
                    return Platform.Android;
                #endif
                
                #if UNITY_STANDALONE
                    return Platform.Desctop;
                #endif
                
                #if UNITY_IOS
                    return Platform.iOS;
                #endif

            }

        }

        public override void Initialize()
        {
            gameStore = _gameStore;
            skin = _skin;

            CompleteInitializing();
        }

        protected override void OnInitialized() { }

    }
}



