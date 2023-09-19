using System;
using System.Collections.Generic;
using UnityEngine;


namespace VG
{
    public class Updater : Initializable
    {

        [System.Serializable]
        public class UpdateHandler
        {
            [SerializeField] private string _key; public string key => _key;
            [SerializeField] private float _timeInterval;
            public event Action onUpdate;

            private float _timeLeft = 0;


            public void SpendTime(float time)
            {
                _timeLeft -= time;
                if (_timeLeft < 0)
                {
                    _timeLeft = _timeInterval;
                    onUpdate?.Invoke();
                }
            }

        }


        [SerializeField] private List<UpdateHandler> _updates;
        public static Dictionary<string, UpdateHandler> updates = new Dictionary<string, UpdateHandler>();


        public override void Initialize()
        {
            foreach (var update in _updates)
                updates.Add(update.key, update);

            CompleteInitializing();
        }



        private void Update()
        {
            foreach (var update in _updates)
                update.SpendTime(Time.deltaTime);
        }

        protected override void OnInitialized() { }
    }
}



