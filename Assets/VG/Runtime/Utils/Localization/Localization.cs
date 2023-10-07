using System;
using System.Collections;
using UnityEngine;


namespace VG
{
    


    public class Localization : Initializable
    {
        private static Localization instance;
        public static event Action onChangeLanguage;
        public static event Action onUpdateToken;

        [SerializeField] private GoogleTables _googleTables;
        [Space(10)]
        [SerializeField] private Strings_LocalizedData _stringData;
        [SerializeField] private Sprites_LocalizedData _spriteData;
        [SerializeField] private TokenData _tokenData;



        public static Language currentLanguage { get; private set; }



        public static void SetLanguage(Language language)
        {
            currentLanguage = language;
            onChangeLanguage?.Invoke();
        }

        public override void Initialize()
        {
            instance = this;
            StartCoroutine(WaitTables());
        }


        private IEnumerator WaitTables()
        {
            while (!_googleTables.initialized && _googleTables.gameObject.activeInHierarchy)
                yield return null;

            _stringData.Initialize();
            _spriteData.Initialize();
            _tokenData.Initialize();

            CompleteInitializing();
        }



        protected override void OnInitialized() { }


        public static string GetString(string key, bool useToken)
        {
            string localizedString = instance._stringData.translations[key].Get(currentLanguage);

            if (useToken)
                foreach (var token in instance._tokenData.tokens)
                {
                    string tokenDefinition = "{" + token.Key + "}";
                    if (localizedString.Contains(tokenDefinition))
                        localizedString = localizedString.Replace(tokenDefinition, token.Value);
                }

            return localizedString;
        }

        public static Sprite GetSprite(string key) 
            => instance._spriteData.translations[key].Get(currentLanguage);


        public static void SetToken(string key, string value)
        {
            instance._tokenData.tokens[key] = value;
            onUpdateToken?.Invoke();
        }

    }


}


