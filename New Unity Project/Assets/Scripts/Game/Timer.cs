using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Timer : MonoBehaviour
    {
        public static event Action OnEndGame;

        [SerializeField] private TimeControl _timeControl;
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private Text _timeSecondsText;
        [SerializeField] private Text _timeMinuteText;
        
        private void Start()
        {
            _timeControl.TimeMinute = _settingsControl.Min -1;
           
            _timeControl.TimeSecond = _timeControl.TimeSecondStart;
            StartCoroutine(TimeBack());
        }
            
        public IEnumerator TimeBack()
        {
            while (_timeControl.TimeMinute >= 0)
            {
                for (int i = 59; i > 0; i--)
                {
                    yield return new WaitForFixedUpdate();
                    _timeControl.TimeSecond -= Time.deltaTime;

                    if (_timeControl.TimeSecond <= 9.5f)
                    {
                        _timeSecondsText.text = 0 + Mathf.Round(_timeControl.TimeSecond).ToString();
                    }
                    else
                    {
                        _timeSecondsText.text = Mathf.Round(_timeControl.TimeSecond).ToString();
                    }

                    if (_timeControl.TimeMinute < 10)
                    {
                        _timeMinuteText.text = 0 + _timeControl.TimeMinute.ToString() + " :";
                    }
                    else
                    {
                        _timeMinuteText.text = _timeControl.TimeMinute.ToString() + " :";
                    }

                    if (_timeControl.TimeSecond <= 0)
                    {
                        _timeControl.TimeMinute--;
                        _timeControl.TimeSecond = _timeControl.TimeSecondStart;
                    }                    
                }
            }
            if (_timeControl.TimeMinute <= 0)
            {
                OnEndGame?.Invoke();
            }
        }
    }
}