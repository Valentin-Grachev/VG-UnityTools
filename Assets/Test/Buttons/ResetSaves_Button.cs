using VG;

public class ResetSaves_Button : ButtonClick
{
    protected override void OnClick()
    {
        Saves.ResetSaves();
    }
}
