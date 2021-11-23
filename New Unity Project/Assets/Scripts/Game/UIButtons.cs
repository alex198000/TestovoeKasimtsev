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
        [SerializeField] protected PersonsHealth _gippoHealth;
        [SerializeField] private PersonsAttack _gippoAttack;
        [SerializeField] private float _gravSnow = 0.5f;

        [SerializeField] protected Timer _timer;

        protected Tween _tween = null;
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
                _scoreControl.Score = 0;               
                SceneManager.LoadScene(1);
                StartCoroutine(_timer.TimeBack());
            }
        }

        public void MenuButton()
        {
            _scoreControl.Score = 0;
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        public void UiFireButton()
        {
            _gippoAttack.Fire(false, _gravSnow);
        }

        private void OnDisable()
        {
            if (DOTween.instance != null)
            {
                _tween?.Kill();
            }
        }
    }
}