using TMPro;
using UnityEngine;
using UnityEngine.Events;


namespace VG
{
    public class LocalizedString : Info
    {
        [SerializeField] private string _key;
        [SerializeField] private bool _useToken;
        [SerializeField] private UnityEvent<string> _onUpdate;

        protected override void Subscribe()
        {
            Localization.onChangeLanguage += UpdateValue;
            if (_useToken) Localization.onUpdateToken += UpdateValue;
        }

        protected override void Unsubscribe()
        {
            Localization.onChangeLanguage -= UpdateValue;
            if (_useToken) Localization.onUpdateToken -= UpdateValue;
        }

        protected override void UpdateValue() => _onUpdate?.Invoke(Localization.GetString(_key, _useToken));


        private void OnValidate()
        {
            if (TryGetComponent<TextMeshProUGUI>(out var text)) text.text = $"<{_key}>";
        }


    }
}



