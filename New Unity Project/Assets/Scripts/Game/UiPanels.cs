using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class UiPanels : MonoBehaviour
    {
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _defeatPanel;
        [SerializeField] private GameObject _pausePanel;        
        [SerializeField] private List<Image> _starImage;
        [SerializeField] private List<Image> _liveImage;       
        [SerializeField] private ParticleSystem _particleWin;
        [SerializeField] private ParticleSystem _particleDefeat;
        [SerializeField] private PersonsHealth _gippoHealth;
        [SerializeField] private bool _lockFunc = false;

        protected Tween _tween;

        public bool LockFunc { get => _lockFunc; set => _lockFunc = value; }

        public static event Action OnTimerStop;

        private void OnEnable()
        {
            Timer.OnEndGame += DefeatPanel;
            LevelManager.OnWinGame += WinPanel;
            PersonsHealth.OnHitGippo += LivePanel;
            PersonsHealth.OnDeathGippo += DefeatPanel;
        }

        private void OnDisable()
        {
            Timer.OnEndGame -= DefeatPanel;
            LevelManager.OnWinGame -= WinPanel;
            PersonsHealth.OnHitGippo -= LivePanel;
            PersonsHealth.OnDeathGippo -= DefeatPanel;

            //_tween.Kill();                       //при раскомите дает ошибку не может найти убитый твин
            //_defeatPanel.transform.DOKill();
            //_winPanel.transform.DOKill();
            //_pausePanel.transform.DOKill();
        }


        public void WinPanel()
        {
            if (_lockFunc != true)                         // ждем когда панель остановится
            {
                if (_winPanel.transform.position.y < 0)    //если панель под экраном
                {
                    _particleWin.Play();   //<ParticleSystem.MainModule>
                    _lockFunc = true;
                    OnTimerStop?.Invoke();
                    Time.timeScale = 0;

                        _tween = _winPanel.transform.DOMove(new Vector3(0, 0, 0), 1f, true).SetEase(Ease.InOutBack).SetUpdate(true).OnComplete(() =>
                        {
                            _lockFunc = false;
                            for (int i = 0; i < _starImage.Count; i++)
                            {
                                switch (_gippoHealth.HpPersons)                            //начисляем зыезды за победу
                                {                                    
                                    case 2:
                                        _starImage[0].gameObject.SetActive(true);
                                        _starImage[1].gameObject.SetActive(false);
                                        _starImage[2].gameObject.SetActive(true);
                                        break;
                                    case 1:
                                        _starImage[0].gameObject.SetActive(false);
                                        _starImage[1].gameObject.SetActive(true);
                                        _starImage[2].gameObject.SetActive(false);
                                        break;
                                    default:
                                        _starImage[0].gameObject.SetActive(true);
                                        _starImage[1].gameObject.SetActive(true);
                                        _starImage[2].gameObject.SetActive(true);
                                        break;
                                }
                            }
                        });
                }
                else
                {
                    _lockFunc = true;
                    Time.timeScale = 1;
                    _tween = _winPanel.transform.DOMove(new Vector3(0, -11, 0), 1f, true).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                    });
                }
            }
        }

        public void DefeatPanel()
        {
            if (_lockFunc != true)
            {
                if (_defeatPanel.transform.position.y < 0)
                {
                    _particleDefeat.Play();
                    _lockFunc = true;
                    OnTimerStop?.Invoke();
                    Time.timeScale = 0;
                    _tween = _defeatPanel.transform.DOMove(new Vector3(0, 0, 0), 1f, true).SetEase(Ease.InOutBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                    });
                }
                else
                {
                    _lockFunc = true;
                    Time.timeScale = 1;
                    _tween = _defeatPanel.transform.DOMove(new Vector3(0, -11, 0), 1f, true).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                    });
                }
            }
        }
        public void LivePanel()
        {
            for (int i = 0; i < _liveImage.Count; i++)
            {
                switch (_gippoHealth.HpPersons)                            //отнимаем сердца
                {
                    case 2:
                        _liveImage[0].gameObject.SetActive(true);
                        _liveImage[1].gameObject.SetActive(true);
                        _liveImage[2].gameObject.SetActive(false);
                        break;
                    case 1:
                        _liveImage[0].gameObject.SetActive(true);
                        _liveImage[1].gameObject.SetActive(false);
                        _liveImage[2].gameObject.SetActive(false);
                        break;
                    case 0:
                        _liveImage[0].gameObject.SetActive(false);
                        _liveImage[1].gameObject.SetActive(false);
                        _liveImage[2].gameObject.SetActive(false);
                        break;
                    default:
                        _liveImage[0].gameObject.SetActive(true);
                        _liveImage[1].gameObject.SetActive(true);
                        _liveImage[2].gameObject.SetActive(true);
                        break;
                }
            }
        }
    }
}