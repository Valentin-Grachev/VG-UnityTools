using TMPro;
using UnityEngine;
using VG;

public class TestString_Info : Info
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Subscribe()
    {
        Saves.String[Key_Save.test_string].onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.String[Key_Save.test_string].onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        _text.text = Saves.String[Key_Save.test_string].Value;
    }

}
