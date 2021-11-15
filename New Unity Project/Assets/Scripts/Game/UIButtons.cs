using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class UIButtons : MonoBehaviour
    {
        [SerializeField] protected UiPanels _uiPanel;
        [SerializeField] protected GameObject _Hippo;
        [SerializeField] protected GameObject _winPanel;
        [SerializeField] protected GameObject _defeatPanel;
        [SerializeField] protected GameObject _pausePanel;
        [SerializeField] protected TimeControl _timeControl;
        [SerializeField] protected ScoreControl _scoreControl;
        [SerializeField] protected SettingsControl _settingsControl;
        [SerializeField] protected LevelManager _levelManager;
        [SerializeField] protected List<Image> _starImage;
        [SerializeField] private ParticleSystem _particleWin;
        [SerializeField] private ParticleSystem _particleDefeat;
        [SerializeField] protected PersonsHealth _gippoHealth;
        [SerializeField] private PersonsAttack _gippoAttack;

        [SerializeField] protected Timer _timer;

        protected Tween _tween;
        public void PauseButton()
        {
            if (_uiPanel.LockFunc != true)
            {
                if (_pausePanel.transform.position.y < 0 && _winPanel.transform.position.y < 0 && _defeatPanel.transform.position.y < 0)
                {
                    _uiPanel.LockFunc = true;
                    Time.timeScale = 0;
                    _tween = _pausePanel.transform.DOMove(new Vector3(0, 0, 0), 1f, true).SetEase(Ease.InOutBack).SetUpdate(true).OnComplete(() =>
                    {
                        _uiPanel.LockFunc = false;
                    });
                }
                else if (_winPanel.transform.position.y < 0 && _defeatPanel.transform.position.y < 0)
                {
                    _uiPanel.LockFunc = true;
                    Time.timeScale = 1;
                    _tween = _pausePanel.transform.DOMove(new Vector3(0, -11, 0), 1f, true).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                    {
                        _uiPanel.LockFunc = false;
                    });
                }
            }
        }

        public void ResumeButton()
        {
            if (_uiPanel.LockFunc != true)
            {
                if (_defeatPanel.transform.position.y < 0 && _winPanel.transform.position.y < 0)
                {
                    //_uiPanel.LockFunc = true;    // блокирует функцию
                    PauseButton();
                }
            }
        }

        public void RepeatButton()
        {
            if (_particleDefeat.isPlaying)
            {
                _particleDefeat.Stop();
            }
            if (_particleWin.isPlaying)
            {
                _particleWin.Stop();
            }
            if (_uiPanel.LockFunc != true)
            {                           
                if (_defeatPanel.transform.position.y >= 0)
                {                       
                    _uiPanel.DefeatPanel();
                }

                if (_winPanel.transform.position.y >= 0)
                {                   
                    _uiPanel.WinPanel();
                }

                for (int i = 0; i < _starImage.Count; i++)
                {
                    _starImage[i].gameObject.SetActive(false);
                }
               
                _Hippo.gameObject.SetActive(true);
                _gippoHealth.HpPersons = _gippoHealth.HpMax;
                _timeControl.TimeMinute = _settingsControl.Min - 1;
                _timeControl.TimeSecond = _timeControl.TimeSecondStart;
                _scoreControl.Score = 0;
                _levelManager.UpdateTextScore();
                _uiPanel.LivePanel();
                //SceneManager.LoadScene(1); 
                StartCoroutine(_timer.TimeBack());
            }
        }

        public void MenuButton()
        {
            SceneManager.LoadScene(0);
        }
        public void UiFireButton()
        {
            _gippoAttack.Fire(false, 0.02f);
        }
    }
}