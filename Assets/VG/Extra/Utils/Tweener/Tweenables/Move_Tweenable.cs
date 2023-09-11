using DG.Tweening;
using UnityEngine;

namespace VG
{
    public class Move_Tweenable : Tweenable
    {
        [SerializeField] private Vector2 _offset;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;

        private RectTransform rectTransform;
        private Vector2 _openedPosition;
        private Vector2 _closedPosition;


        private void Awake()
        {
            rectTransform = transform.GetComponent<RectTransform>();

            if (opened)
            {
                _openedPosition = rectTransform.anchoredPosition;
                _closedPosition = rectTransform.anchoredPosition + _offset;
            }
            else
            {
                _openedPosition = rectTransform.anchoredPosition + _offset;
                _closedPosition = rectTransform.anchoredPosition;
            }

        }



        protected override void CloseAction()
        {
            var tween = rectTransform.DOAnchorPos(_closedPosition, _duration);
            tween.onComplete += () => OnEnd();
            tween.SetEase(_ease);

        }


        protected override void OpenAction()
        {
            var tween = rectTransform.DOAnchorPos(_openedPosition, _duration);
            tween.onComplete += () => OnEnd();
            tween.SetEase(_ease);
        }
    }
}


