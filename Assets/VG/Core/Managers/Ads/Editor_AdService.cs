using System;
using VG.Internal;


namespace VG
{
    public class Editor_AdService : AdService
    {
        public override bool supported => Platform.editor;

        public override void Initialize() => CompleteInitializing();

        public override void SetBanner(bool show)
        {
            if (show) Core.LogEditor($"Show banner.");
            else Core.LogEditor($"Hide banner.");
        }


        public override void Show(Ads.AdType adType, string key_ad, Action<bool> onSuccess)
        {
            Core.LogEditor($"{adType} success shown, key: {key_ad}.");
            onSuccess?.Invoke(true);
        }

        protected override void OnInitialized() { }
    }
}


