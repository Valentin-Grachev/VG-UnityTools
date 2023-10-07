using System;
using System.Collections;
using VG.YandexGames;

namespace VG
{
    public class YandexGames_AdService : AdService
    {


        public override bool supported =>
            Environment.gameStore == Environment.GameStore.YandexGames
            && Environment.platform == Environment.Platform.WebGL && !Environment.editor;

        public override void Initialize()
        {
            StartCoroutine(WaitYandexSDK());
        }

        private IEnumerator WaitYandexSDK()
        {
            while (!YG_Sdk.available) yield return null;
            CompleteInitializing();
        }


        
        

        public override void Show(Ads.AdType adType, string key_ad, Action<bool> onSuccess)
        {
            switch (adType)
            {
                case Ads.AdType.Rewarded:
                    bool playerRewarded = false;

                    YG_Ads.ShowRewarded((action) => 
                    {
                        switch (action)
                        {
                            case YG_Ads.RewardedAction.Opened:
                                Pause.Set(true);
                                break;

                            case YG_Ads.RewardedAction.Closed:
                                Pause.Set(false);
                                onSuccess?.Invoke(playerRewarded);
                                break;

                            case YG_Ads.RewardedAction.Rewarded:
                                playerRewarded = true;
                                break;
                        }

                    });
                    break;

                case Ads.AdType.Interstitial:
                    bool interstitialWasShown = false;
                    Pause.Set(true);

                    YG_Ads.ShowInterstitial((action) =>
                    {
                        switch (action)
                        {
                            case YG_Ads.InterstitialAction.Opened:
                                interstitialWasShown = true;
                                break;

                            case YG_Ads.InterstitialAction.Closed:
                                Pause.Set(false);
                                onSuccess?.Invoke(interstitialWasShown);
                                break;
                        }

                    });
                    break;

            }
        }

        protected override void OnInitialized() { }

        public override void SetBanner(bool show)
        {
            if (show) YG_Ads.ShowBanner();
            else YG_Ads.HideBanner();
        }
    }
}



