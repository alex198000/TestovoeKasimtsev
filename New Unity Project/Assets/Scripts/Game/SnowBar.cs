using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SnowBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Image anch;
        [SerializeField] private Text _fillText;

        public Slider Slider { get => _slider; set => _slider = value; }

        public void SetMaxHealth(float power)
        {
            _slider.maxValue = power;
            _slider.value = power;
            anch.color = _gradient.Evaluate(1f);
            _fillText.color = _gradient.Evaluate(1f);
        }
        public void SetHealth(float power)
        {
            _slider.value = power;
            anch.color = _gradient.Evaluate(_slider.normalizedValue);
            _fillText.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }
}