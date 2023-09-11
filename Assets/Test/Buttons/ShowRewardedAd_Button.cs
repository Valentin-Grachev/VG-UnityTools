using UnityEngine;
using VG;

public class ShowRewardedAd_Button : ButtonClick
{
    protected override void OnClick()
    {
        Ads.Rewarded.Show(Key_Ad.test_example_1, (success) =>
        {
            if (success) button.image.color = Color.green;
            else button.image.color = Color.red;
        });

    }
}
