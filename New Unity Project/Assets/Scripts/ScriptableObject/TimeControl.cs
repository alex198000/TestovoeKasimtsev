using UnityEngine;

namespace Game
{

    [CreateAssetMenu(fileName = "TimeControl", menuName = "ScriptableObjects/NewTimeControl")]
    public class TimeControl : ScriptableObject
    {
        [SerializeField] private float _timeSecondStart;
        [SerializeField] private float _timeSecond;
        [SerializeField] private int _timeMinute;
        [SerializeField] private int _timeMinuteStart;   //  = PlayerPrefs.GetInt("Min")

        public float TimeSecondStart { get => _timeSecondStart; set => _timeSecondStart = value; }
        public int TimeMinute { get => _timeMinute; set => _timeMinute = value; }
        public float TimeSecond { get => _timeSecond; set => _timeSecond = value; }
        public int TimeMinuteStart { get => _timeMinuteStart; set => _timeMinuteStart = value; }

        public void OnEnable()
        {
            TimeMinute = TimeMinuteStart;
        }
    }
}