using System;
using System.Runtime.InteropServices;
using UnityEngine;



namespace VG.YandexGames
{
    public class YG_Ads : MonoBehaviour
    {
        public enum RewardedAction { Opened, Closed, Rewarded, Failed };
        public enum InterstitialAction { Opened, Closed, Failed };




        public static void ShowRewarded(Action<RewardedAction> onAction)
        {
            _onRewardedAction = onAction;
            ShowRewarded();
        }


        public static void ShowInterstitial(Action<InterstitialAction> onAction)
        {
            _onInterstitialAction = onAction;
            ShowInterstitial();
        }

        [DllImport("__Internal")] public static extern void ShowBanner();

        [DllImport("__Internal")] public static extern void HideBanner();



        #region Internal

        private static event Action<RewardedAction> _onRewardedAction;
        [DllImport("__Internal")] private static extern void ShowRewarded();
        public void HTML_OnRewardedAction(string actionTypeString)
        {
            Enum.TryParse(actionTypeString, out RewardedAction actionType);
            _onRewardedAction?.Invoke(actionType);
        }



        private static event Action<InterstitialAction> _onInterstitialAction;
        [DllImport("__Internal")] private static extern void ShowInterstitial();
        public void HTML_OnInterstitialAction(string actionTypeString)
        {
            Enum.TryParse(actionTypeString, out InterstitialAction actionType);
            _onInterstitialAction?.Invoke(actionType);
        }


        #endregion


    }
}



