using System;
using VG.Internal;


namespace VG
{
    public class Ads : Manager
    {
        public enum AdType { Rewarded, Interstitial }
        public delegate void OnShown(string key_ad, bool success);

        private static Ads instance; 

        private static AdService service => instance.supportedService as AdService;
        protected override string managerName => "VG Ads";


        protected override void OnInitialized()
        {
            instance = this;
            Log(Core.Message.Initialized(managerName));
        }



        public static class Rewarded
        {
            public static event OnShown onShown;

            public static void Show(string key_ad = "none", Action<bool> onSuccess = null)
            {
                instance.Log("Request rewarded ad. Ad key: " + key_ad);

                service.Show(AdType.Rewarded, key_ad, (success) =>
                {
                    onSuccess?.Invoke(success);
                    onShown?.Invoke(key_ad, success);

                    if (success) instance.Log("On rewarded. Ad key: " + key_ad);
                    else instance.Log("On not rewarded. Ad key: " + key_ad);
                });
            }
        }



        public static class Interstitial
        {
            public static event OnShown onShown;

            public static void Show(string key_ad = "none", Action<bool> onSuccess = null)
            {
                instance.Log("Request interstitial ad. Ad key: " + key_ad);

                service.Show(AdType.Interstitial, key_ad, (success) =>
                {
                    onSuccess?.Invoke(success);
                    onShown?.Invoke(key_ad, success);

                    if (success) instance.Log("On interstitial shown. Ad key: " + key_ad);
                    else instance.Log("On interstitial failed. Ad key: " + key_ad);
                });
                return;
            }


        }

        public static class Banner
        {
            public static void Set(bool show) => service.SetBanner(show);

        }


    }
}




