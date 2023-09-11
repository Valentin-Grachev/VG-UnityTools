using System;
using System.Runtime.InteropServices;
using UnityEngine;



namespace VG.YandexGames
{
    public class YG_Saves : MonoBehaviour
    {
        
        public static bool available { get { CheckPlayerInit(); return _playerInitialized; } }


        public static void RequestSaves(Action<string> onSavesDataReceived)
        {
            _onSavesDataReceived = onSavesDataReceived;
            RequestSaves();
        }

        public static void SendSaves(string savesData, Action<bool> onSavesSent)
        {
            _onSavesSent = onSavesSent;
            SendSaves(savesData);
        }


        [DllImport("__Internal")] public static extern void InitializePlayer();



        #region Internal

        private static bool _playerInitialized = false;

        [DllImport("__Internal")] private static extern void CheckPlayerInit();
        private void HTML_OnPlayerInitChecked(int initialized) => _playerInitialized = Convert.ToBoolean(initialized);




        private static event Action<bool> _onSavesSent;
        [DllImport("__Internal")] private static extern void SendSaves(string savesData);
        private void HTML_OnSavesSent(int success) => _onSavesSent?.Invoke(Convert.ToBoolean(success));



        private static event Action<string> _onSavesDataReceived;
        [DllImport("__Internal")] private static extern void RequestSaves();
        private void HTML_OnSavesReceived(string savesData) => _onSavesDataReceived?.Invoke(savesData);


        #endregion



        
        
        


    }
}


