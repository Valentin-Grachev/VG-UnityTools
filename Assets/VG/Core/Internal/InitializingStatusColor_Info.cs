using UnityEngine;
using UnityEngine.Events;

namespace VG
{
    public class InitializingStatusColor_Info : MonoBehaviour
    {
        [SerializeField] private Initializable _initializable;
        [SerializeField] private UnityEvent<Color> _onStatusColor;


        private void Update()
        {
            if (_initializable.initialized) _onStatusColor.Invoke(Color.green);
            else _onStatusColor.Invoke(Color.yellow);
        }



    }

}

