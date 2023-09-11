using VG;

public class HideBanner_Button : ButtonClick
{

    protected override void OnClick() => Ads.Banner.Set(show: false);

}
