using UnityEngine;


namespace VG
{
    public class Platform : Initializable
    {
        public enum System { Android, WebGL, Desctop, iOS }
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

        public static System system 
        { 
            get
            {
                #if UNITY_WEBGL
                    return System.WebGL;
                #endif
                
                #if UNITY_ANDROID
                    return Type.Android;
                #endif
                
                #if UNITY_STANDALONE
                    return Type.Desctop;
                #endif
                
                #if UNITY_IOS
                    return Type.iOS;
                #endif

            }

        }

        public override void Initialize()
        {
            gameStore = _gameStore;
            skin = _skin;
        }

        protected override void OnInitialized() { }

    }
}



