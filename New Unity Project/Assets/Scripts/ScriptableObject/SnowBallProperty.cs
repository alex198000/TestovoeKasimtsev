using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "SnowBallProperty", menuName = "ScriptableObjects/NewSnowBallProperty")]
    public class SnowBallProperty : ScriptableObject
    {
        [SerializeField] private float _snowBallSpeedValue;

        public float SpeedSnowBallValue
        {
            get
            {
                return _snowBallSpeedValue;
            }
            set
            {
                _snowBallSpeedValue = value;
            }
        }
    }
}
