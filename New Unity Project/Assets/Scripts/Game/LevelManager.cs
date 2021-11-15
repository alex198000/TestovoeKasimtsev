using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private ScoreControl _scoreControl;
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private Text _scoreText;

        public static event Action OnWinGame;
        private void OnEnable()
        {
            _scoreControl.ScoreWin = _settingsControl.ScoreToWin;
            PersonsHealth.OnHitEnemy += UpdateTextScore;
            PersonsHealth.OnHitEnemy += WinCheck;
        }

        private void OnDisable()
        {
            PersonsHealth.OnHitEnemy -= UpdateTextScore;
            PersonsHealth.OnHitEnemy -= WinCheck;
        }
       
        private void WinCheck()
        {
            if (_scoreControl.Score >= _scoreControl.ScoreWin)
            {
                OnWinGame?.Invoke();
            }
        }
            public void UpdateScore()
        {
            _scoreControl.Score += 20;
        }

        public void UpdateTextScore()
        {
            if(_scoreControl.Score < 10)
            { 
               _scoreText.text = 0 + _scoreControl.Score.ToString();
            }
            else
            {
                _scoreText.text = _scoreControl.Score.ToString();
            }
        }
    }
}