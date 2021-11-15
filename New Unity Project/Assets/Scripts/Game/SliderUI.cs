using System.Collections;
using UnityEngine;

namespace Game
{
    public class SliderUI : MonoBehaviour
    {
        [SerializeField] private SnowBar _snowBar;
        [SerializeField] private SnowBallScript _snowBallScript;
        [SerializeField] private SnowBallProperty _snowBallProperty;
        [SerializeField] private float _speedSnowBallMax = 50f;
        void Start()
        {
            _snowBallProperty.SpeedSnowBallValue = _speedSnowBallMax;
            //_snowBar.SetMaxHealth(_snowBallScript.SpeedSnowBall);
            _snowBar.SetMaxHealth(_snowBallProperty.SpeedSnowBallValue);
            StartCoroutine(SpeedDown());
        }

        IEnumerator SpeedDown()                   // уменьшение шкалы скорости
        {
            while (_snowBallProperty.SpeedSnowBallValue > 0)
            {
                _snowBallProperty.SpeedSnowBallValue--;
                //_snowBar.SetHealth(_snowBallScript.SpeedSnowBall);
                _snowBar.SetHealth(_snowBallProperty.SpeedSnowBallValue);
                yield return new WaitForFixedUpdate();
            }
            StartCoroutine(SpeedUp());
            yield return null;                              // выход из корутины
        }
        IEnumerator SpeedUp()                   // увеличение шкалы скорости
        {
            while (_snowBallProperty.SpeedSnowBallValue < _speedSnowBallMax)
            {
                _snowBallProperty.SpeedSnowBallValue++;
                //_snowBar.SetHealth(_snowBallScript.SpeedSnowBall);
                _snowBar.SetHealth(_snowBallProperty.SpeedSnowBallValue);
                yield return new WaitForFixedUpdate();
            }
            StartCoroutine(SpeedDown());
            yield return null;                              // выход из корутины
        }
    }
}