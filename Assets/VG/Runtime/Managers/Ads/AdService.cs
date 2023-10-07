using System;
using VG.Internal;


namespace VG
{

    public abstract class AdService : Service
    {
        public abstract void Show(Ads.AdType adType, string key_ad, Action<bool> onSuccess);

        public abstract void SetBanner(bool show);

    }
}
