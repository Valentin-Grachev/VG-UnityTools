using System;
using UnityEngine;

namespace VG
{
    public abstract class Tweenable : MonoBehaviour
    {
        public event Action onStartTweening;
        public event Action onEndTweening;


        [SerializeField] private bool _opened; protected bool opened => _opened;

        private bool _tweening = false;

        public void Open()
        {
            if (_opened || _tweening) return;

            OpenAction();
            _opened = true;
            _tweening = true;
            onStartTweening?.Invoke();
        }

        public void Close()
        {
            if (!_opened || _tweening) return;

            CloseAction();
            _opened = false;
            _tweening = true;
            onStartTweening?.Invoke();
        }


        protected abstract void OpenAction();
        protected abstract void CloseAction();

        protected void OnEnd()
        {
            _tweening = false;
            onEndTweening?.Invoke();
        }




    }
}

