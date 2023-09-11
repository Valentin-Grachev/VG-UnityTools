using System;
using System.Collections;
using UnityEngine;
using VG.YandexGames;

namespace VG
{
    public class YandexGames_SaveService : SaveService
    {
        private string _savesData = null;



        public override bool supported => 
            Platform.gameStore == Platform.GameStore.YandexGames 
            && Platform.system == Platform.System.WebGL && !Platform.editor;


        public override void Commit(string data, Action<bool> onCommited)
            => YG_Saves.SendSaves(data, (success) => onCommited?.Invoke(success));



        public override string GetData() => _savesData;

        public override void Initialize()
        {
            StartCoroutine(SavesInitializing());
        }


        private IEnumerator SavesInitializing()
        {
            while (!YG_Saves.available)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                YG_Saves.InitializePlayer();
            }

            YG_Saves.RequestSaves((savesData) =>
            {
                _savesData = savesData;
                CompleteInitializing();
            });

            
        }


        protected override void OnInitialized() { }

        
    }
}


