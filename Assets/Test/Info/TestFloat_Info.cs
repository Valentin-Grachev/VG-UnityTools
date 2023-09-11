using TMPro;
using UnityEngine;
using VG;


public class TestFloat_Info : Info
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Subscribe()
    {
        Saves.Float[Key_Save.test_float].onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.Float[Key_Save.test_float].onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        _text.text = Saves.Float[Key_Save.test_float].Value.ToString();
    }
}
