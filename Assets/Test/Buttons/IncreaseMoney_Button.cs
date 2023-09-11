using VG;


public class IncreaseMoney_Button : ButtonClick
{

    protected override void OnClick()
    {
        Saves.Int[Key_Save.money].Value++;
        Saves.String[Key_Save.test_string].Value += "1";
        Saves.Float[Key_Save.test_float].Value += 0.5f;
    }
}
