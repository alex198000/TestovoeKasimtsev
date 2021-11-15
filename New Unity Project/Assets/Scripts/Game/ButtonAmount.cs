using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ButtonAmount : MonoBehaviour
    {
        [SerializeField] private Image _buttonAmount;
        [SerializeField] private PersonsAttack _gippoAttack;

        private void FixedUpdate()
        {
            _buttonAmount.fillAmount =  _gippoAttack.NextFire / _gippoAttack.FireRate;
        }
    }
}