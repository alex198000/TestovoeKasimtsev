using Game;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuButtonScript : MonoBehaviour
    {
        [SerializeField] private MenuScript _menuScript;
        [SerializeField] private UISettings _uiSettings;
        [SerializeField] private SettingsControl _settingsControl;

        private int _musicON = 1;
        private int _soundON = 1;
        private int _soundEffON = 1;

        public void StartButton()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void ResetButton()
        {
            _uiSettings.MinText.text = string.Empty;
            _uiSettings.SpeedEnemyText.text = string.Empty;
            _uiSettings.GippoSpeedText.text = string.Empty;
            _uiSettings.ScoreToWinText.text = string.Empty;
            _uiSettings.ScoreToHitEnemyText.text = string.Empty;
            _uiSettings.SpeedRateText.text = string.Empty;
            _uiSettings.SpeedEnemyAttackText.text = string.Empty;
        }

        //public float String2Float(string line)            // меняем запятую на точку во флоат при конвертировании
        //{
        //    float res;
        //    try
        //    {
        //        string sp = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
        //        line = line.Replace(".", sp);
        //        line = line.Replace(",", sp);
        //        res = float.Parse(line);
        //    }
        //    catch
        //    {
        //        res = 0f;
        //    }

        //    return res;
        //}
        public void SaveSettings()
        {
            if(_uiSettings.MinText.text.Length == 0)
            {
                _uiSettings.MinText.text = _settingsControl.Min.ToString();
            }
            else
            {
                _uiSettings.Min = Convert.ToInt32(_uiSettings.MinText.text);
                _settingsControl.Min = _uiSettings.Min;
                PlayerPrefs.SetInt("Min", _uiSettings.Min);
            }

            if (_uiSettings.SpeedEnemyText.text.Length == 0)
            {
                _uiSettings.SpeedEnemyText.text = _settingsControl.SpeedEnemy.ToString();
            }
            else
            {
                _uiSettings.SpeedEnemy = Convert.ToSingle(_uiSettings.SpeedEnemyText.text);     // float.Parse(_uiSettings.SpeedEnemyText.text);
                _settingsControl.SpeedEnemy = _uiSettings.SpeedEnemy;
                PlayerPrefs.SetFloat("SpeedEnemy", _uiSettings.SpeedEnemy);
            }

            if (_uiSettings.GippoSpeedText.text.Length == 0)
            {
                _uiSettings.GippoSpeedText.text = _settingsControl.GippoSpeed.ToString();
            }
            else
            {
                _uiSettings.GippoSpeed = Convert.ToSingle(_uiSettings.GippoSpeedText.text);
                _settingsControl.GippoSpeed = _uiSettings.GippoSpeed;
                PlayerPrefs.SetFloat("GippoSpeed", _uiSettings.GippoSpeed);
            }

            if (_uiSettings.ScoreToWinText.text.Length == 0)
            {
                _uiSettings.ScoreToWinText.text = _settingsControl.ScoreToWin.ToString();
            }
            else
            {
                _uiSettings.ScoreToWin = Convert.ToInt32(_uiSettings.ScoreToWinText.text);
                _settingsControl.ScoreToWin = _uiSettings.ScoreToWin;
                PlayerPrefs.SetInt("ScoreToWin", _uiSettings.ScoreToWin);
            }

            if (_uiSettings.ScoreToHitEnemyText.text.Length == 0)
            {
                _uiSettings.ScoreToHitEnemyText.text = _settingsControl.ScoreToHitEnemy.ToString();
            }
            else
            {
                _uiSettings.ScoreToHitEnemy = Convert.ToInt32(_uiSettings.ScoreToHitEnemyText.text);
                _settingsControl.ScoreToHitEnemy = _uiSettings.ScoreToHitEnemy;
                PlayerPrefs.SetInt("ScoreToHitEnemy", _uiSettings.ScoreToHitEnemy);
            }

            if (_uiSettings.SpeedRateText.text.Length == 0)
            {
                _uiSettings.SpeedRateText.text = _settingsControl.SpeedRate.ToString();
            }
            else
            {
                _uiSettings.SpeedRate = Convert.ToSingle(_uiSettings.SpeedRateText.text);
                _settingsControl.SpeedRate = _uiSettings.SpeedRate;
                PlayerPrefs.SetFloat("SpeedRate", _uiSettings.SpeedRate);
            }

            if (_uiSettings.SpeedEnemyAttackText.text.Length == 0)
            {
                _uiSettings.SpeedEnemyAttackText.text = _settingsControl.SpeedEnemyAttack.ToString();
            }
            else
            {
                _uiSettings.SpeedEnemyAttack = Convert.ToSingle(_uiSettings.SpeedEnemyAttackText.text);
                _settingsControl.SpeedEnemyAttack = _uiSettings.SpeedEnemyAttack;
                PlayerPrefs.SetFloat("SpeedEnemyAttack", _uiSettings.SpeedEnemyAttack);
            }            
        }

        public void MusicButton()
        {
            _menuScript.PLost.GetComponent<AudioSource>().mute = !_menuScript.PLost.GetComponent<AudioSource>().mute;

            if (_menuScript.PLost.GetComponent<AudioSource>().mute == true)
            {
                PlayerPrefs.SetInt("Music", _menuScript.MusicOFF);

                _menuScript.MusicLock.gameObject.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("Music", _musicON);

                _menuScript.MusicLock.gameObject.SetActive(false);
            }
        }

        public void SoundEffectsButton()
        {
            _menuScript.P1effectLost.GetComponent<AudioSource>().mute = !_menuScript.P1effectLost.GetComponent<AudioSource>().mute;
            if (_menuScript.P1effectLost.GetComponent<AudioSource>().mute == true)
            {
                PlayerPrefs.SetInt("SoundEff", _menuScript.SoundEffOFF);
                _menuScript.SoundEffLock.gameObject.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("SoundEff", _soundEffON);
                _menuScript.SoundEffLock.gameObject.SetActive(false);
            }
        }
        public void SoundButton()
        {
            AudioListener.pause = !AudioListener.pause;

            if (AudioListener.pause)
            {

                PlayerPrefs.SetInt("Sound", _menuScript.SoundOFF);

                _menuScript.SoundLock.gameObject.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetInt("Sound", _soundON);

                _menuScript.SoundLock.gameObject.SetActive(false);
            }
        }

        public void Start1Button()
        {
            SceneManager.LoadScene(1);
        }
    }
}