using System.Collections;
using VG.YandexGames;

namespace VG
{
    public class YandexGames_SystemLanguageService : LangDefinerService
    {
        public override bool supported =>
            Environment.gameStore == Environment.GameStore.YandexGames &&
            Environment.platform == Environment.Platform.WebGL;


        private LangDefiner.Language _browserLanguage;




        public override LangDefiner.Language GetLanguage() => _browserLanguage;

        public override void Initialize()
        {
            StartCoroutine(RequestLanguage());
        }


        private IEnumerator RequestLanguage()
        {
            while (!YG_Sdk.available) yield return null;

            string language = YG_Sdk.GetLanguage();
            print("From unity: " + language);
            switch (language)
            {
                case "ru": _browserLanguage = LangDefiner.Language.RU;
                    break;

                case "tr": _browserLanguage = LangDefiner.Language.TR;
                    break;

                case "en":
                    _browserLanguage = LangDefiner.Language.EN;
                    break;


                default: _browserLanguage = LangDefiner.Language.EN;
                    break;
            }

            CompleteInitializing();
        }


        protected override void OnInitialized() { }

    }
}



