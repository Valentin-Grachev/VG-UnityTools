using VG;


public class Review_Button : ButtonClick
{
    protected override void OnClick()
    {
        Review.Request();
    }
}
