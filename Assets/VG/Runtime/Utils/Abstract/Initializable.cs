using UnityEngine;


namespace VG
{
    public abstract class Initializable : MonoBehaviour
    {
        public bool initialized { get; private set; }

        public abstract void Initialize();

        protected abstract void OnInitialized();

        protected void CompleteInitializing()
        {
            initialized = true;
            OnInitialized();
        }




    }
}


