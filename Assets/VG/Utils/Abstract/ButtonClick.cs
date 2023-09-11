using UnityEngine;
using UnityEngine.UI;


namespace VG
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonClick : MonoBehaviour
    {
        public Button button { get; private set; }


        protected virtual void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }


        protected abstract void OnClick();

    }
}


