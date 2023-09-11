using UnityEngine;

namespace VG
{
    public class SpriteSlider : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _fill;

        private float _value = 1f;
        private float _fillWidth;

        private void Awake() => _fillWidth = _fill.size.x;

        public float value
        {
            get => _value;
            set
            {
                float newWidth = value * _fillWidth;
                _fill.size = new Vector2(newWidth, _fill.size.y);
            }
        }
    }
}



