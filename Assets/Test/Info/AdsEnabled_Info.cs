using TMPro;
using UnityEngine;
using VG;


public class AdsEnabled_Info : Info
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Subscribe()
    {
        Saves.Bool[Key_Save.ads_enabled].onChanged += UpdateValue;
    }

    protected override void Unsubscribe()
    {
        Saves.Bool[Key_Save.ads_enabled].onChanged -= UpdateValue;
    }

    protected override void UpdateValue()
    {
        _text.text = "Ads: " + Saves.Bool[Key_Save.ads_enabled].Value.ToString();
    }
}
