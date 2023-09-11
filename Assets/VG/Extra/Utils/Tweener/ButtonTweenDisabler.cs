using UnityEngine;
using UnityEngine.UI;

namespace VG
{
    [RequireComponent(typeof(Button))]
    public class ButtonTweenDisabler : MonoBehaviour
    {
        [SerializeField] private Tweenable _tweenable;

        private Button _button;

        private bool _originButtonInteractable;


        private void OnEnable()
        {
            _button ??= GetComponent<Button>();

            _tweenable.onStartTweening += OnStartTweening;
            _tweenable.onEndTweening += OnEndTweening;
        }

        private void OnDisable()
        {
            _tweenable.onStartTweening -= OnStartTweening;
            _tweenable.onEndTweening -= OnEndTweening;
        }


        private void OnEndTweening()
        {
            _button.interactable = _originButtonInteractable;
        }

        private void OnStartTweening()
        {
            _originButtonInteractable = _button.interactable;
            _button.interactable = false;
        }
    }
}


