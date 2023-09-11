using UnityEngine;
using VG;

public class ShowInterstitialAd_Button : ButtonClick
{
    protected override void OnClick()
    {
        Ads.Interstitial.Show(Key_Ad.test_example_2, (success) =>
        {
            if (success) button.image.color = Color.green;
            else button.image.color = Color.red;
        });
    }
}
