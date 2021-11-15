using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SnowBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
      
        [SerializeField] private Image fill;

        public Slider Slider { get => _slider; set => _slider = value; }

        public void SetMaxHealth(float power)
        {
            _slider.maxValue = power;
            _slider.value = power;
        }
        public void SetHealth(float power)
        {
            _slider.value = power;
        }
    }
}