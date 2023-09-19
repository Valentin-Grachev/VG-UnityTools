using System;
using System.Runtime.InteropServices;
using UnityEngine;


namespace VG.YandexGames
{
    public class YG_Sdk : MonoBehaviour
    {



        private static bool _sdkInitialized = false;
        public static bool available { get { CheckSdkInit(); return _sdkInitialized; } }


        [DllImport("__Internal")] private static extern void CheckSdkInit();
        private void HTML_OnSdkInitChecked(int initialized) => _sdkInitialized = Convert.ToBoolean(initialized);



        public static string GetLanguage()
        {
            RequestLanguage();
            return _receivedLanguage;
        }


        private static string _receivedLanguage;
        [DllImport("__Internal")] private static extern string RequestLanguage();
        private void HTML_OnLanguageReceived(string language) => _receivedLanguage = language;



    }
}



