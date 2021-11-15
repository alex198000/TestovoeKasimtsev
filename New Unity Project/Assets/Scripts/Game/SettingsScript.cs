using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SettingsScript : MonoBehaviour
    {
        [SerializeField] private GameObject _pLost;
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private Text _minText;
        [SerializeField] private Text _speedEnemyText;
        [SerializeField] private Text _gippoSpeedText;
        [SerializeField] private Text _scoreToWinText;
        [SerializeField] private Text _scoreToHitEnemyText;
        [SerializeField] private Text _speedRateText;
        [SerializeField] private Text _speedEnemyAttackText;
        [SerializeField] private List<ParticleSystem> _particles;


        void Start()
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                _pLost.GetComponent<AudioSource>().mute = true;
            }
            else
            {
                _pLost.GetComponent<AudioSource>().mute = false;
            }

            if (PlayerPrefs.GetInt("SoundEff") == 0)
            {
                foreach (ParticleSystem partikl in _particles)
                {
                    partikl.GetComponent<AudioSource>().mute = true;
                }
            }
            else
            {                
                foreach (ParticleSystem partikl in _particles)
                {
                    partikl.GetComponent<AudioSource>().mute = false;
                }
            }

            _minText.text = _settingsControl.Min.ToString();
            _speedEnemyText.text = _settingsControl.SpeedEnemy.ToString();
            _gippoSpeedText.text = _settingsControl.GippoSpeed.ToString();
            _scoreToWinText.text = _settingsControl.ScoreToWin.ToString();
            _scoreToHitEnemyText.text = _settingsControl.ScoreToHitEnemy.ToString();
            _speedRateText.text = _settingsControl.SpeedRate.ToString();
            _speedEnemyAttackText.text = _settingsControl.SpeedEnemyAttack.ToString();
        }
    }
}