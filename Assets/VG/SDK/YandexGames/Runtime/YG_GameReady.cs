using System.Runtime.InteropServices;
using UnityEngine;


namespace VG.YandexGames
{
    public class YG_GameReady : MonoBehaviour
    {



        void Start()
        {
            if (Environment.gameStore == Environment.GameStore.YandexGames)
                GameReady();

        }

        [DllImport("__Internal")] private static extern void GameReady();



    }


}
    
