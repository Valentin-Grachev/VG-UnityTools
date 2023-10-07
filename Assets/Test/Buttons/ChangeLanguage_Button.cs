using VG;


public class ChangeLanguage_Button : ButtonClick
{
    protected override void OnClick()
    {
        if (Localization.currentLanguage == Language.RU)
            Localization.SetLanguage(Language.EN);

        else Localization.SetLanguage(Language.RU);





    }
}
