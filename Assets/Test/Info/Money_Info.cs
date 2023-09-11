using TMPro;
using UnityEngine;
using VG;


public class Money_Info : Info
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Subscribe()
    {
        Saves.Int[Key_Save.money].onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.Int[Key_Save.money].onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        _text.text = Saves.Int[Key_Save.money].Value.ToString();
    }

}
