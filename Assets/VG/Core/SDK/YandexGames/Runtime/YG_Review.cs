using System.Runtime.InteropServices;
using UnityEngine;


namespace VG.YandexGames
{
    public class YG_Review : MonoBehaviour
    {

        public static void Request() => RequestReview();

        [DllImport("__Internal")] private static extern void RequestReview();


    }
}


