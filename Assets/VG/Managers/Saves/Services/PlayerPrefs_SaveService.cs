using UnityEngine;
using NaughtyAttributes;
using System;

namespace VG
{
    public class PlayerPrefs_SaveService : SaveService
    {
        public override bool supported => true;

        public override void Commit(string data, Action<bool> onCommited)
        {
            PlayerPrefs.SetString("data", data);
            PlayerPrefs.Save();
            onCommited?.Invoke(true);
        }

        public override string GetData() => PlayerPrefs.GetString("data", string.Empty);

        public override void Initialize() { }

        protected override void OnInitialized() { }

        [Button("Clear data")]
        private void ClearData() => PlayerPrefs.DeleteAll();

    }

}

