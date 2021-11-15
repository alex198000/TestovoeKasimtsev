using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MenuScript : MonoBehaviour
    {
        [SerializeField] private GameObject _pLost;
        [SerializeField] private GameObject _p1effectLost;
        [SerializeField] private Image _soundLock;
        [SerializeField] private Image _musicLock;
        [SerializeField] private Image _soundEffLock;
        [SerializeField] private GameObject _exitMenu;
        [SerializeField] private GameObject _setMenu;
        
        [SerializeField] private List<Button> _button;
        [SerializeField] private List<ParticleSystem> particles;
        [SerializeField] protected bool _lockFunc = false;
        private int _musicOFF = 0;
        private int _soundEffOFF = 0;
        private int _soundOFF = 0;        

        private Tween _tween;

        public GameObject PLost { get => _pLost; set => _pLost = value; }
        public GameObject P1effectLost { get => _p1effectLost; set => _p1effectLost = value; }
        public Image SoundEffLock { get => _soundEffLock; set => _soundEffLock = value; }
        public Image MusicLock { get => _musicLock; set => _musicLock = value; }
        public Image SoundLock { get => _soundLock; set => _soundLock = value; }
        public int SoundEffOFF { get => _soundEffOFF; set => _soundEffOFF = value; }
        public int MusicOFF { get => _musicOFF; set => _musicOFF = value; }
        public int SoundOFF { get => _soundOFF; set => _soundOFF = value; }

        private void Awake()
        {
            if (!PlayerPrefs.HasKey("Sound"))       //активация звуков при 1 включении
            {
                PlayerPrefs.SetInt("Sound", 1);
            }
            if (!PlayerPrefs.HasKey("SoundEff"))
            {
                PlayerPrefs.SetInt("SoundEff", 1);
            }
            if (!PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.SetInt("Music", 1);
            }
            if (!PlayerPrefs.HasKey("Min"))       //активация настроек при 1 включении
            {
                PlayerPrefs.SetInt("Min", 10);
            }
            if (!PlayerPrefs.HasKey("SpeedEnemy"))
            {
                PlayerPrefs.SetFloat("SpeedEnemy", 2.2f);
            }
            if (!PlayerPrefs.HasKey("GippoSpeed"))
            {
                PlayerPrefs.SetFloat("GippoSpeed", 2.5f);
            }
            if (!PlayerPrefs.HasKey("ScoreToWin"))
            {
                PlayerPrefs.SetInt("ScoreToWin", 10);
            }
            if (!PlayerPrefs.HasKey("ScoreToHitEnemy"))
            {
                PlayerPrefs.SetInt("ScoreToHitEnemy", 2);
            }
            if (!PlayerPrefs.HasKey("SpeedRate"))
            {
                PlayerPrefs.SetFloat("SpeedRate", 2.0f);
            }
            if (!PlayerPrefs.HasKey("SpeedEnemyAttack"))
            {
                PlayerPrefs.SetFloat("SpeedEnemyAttack", 5.5f);
            }
        }
        public void Start()
        {
            if (PlayerPrefs.GetInt("Sound") == _soundOFF)
            {
                AudioListener.pause = true;
               
                _soundLock.gameObject.SetActive(true);
            }
            else
            {
                AudioListener.pause = false;
               
                _soundLock.gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("Music") == _musicOFF)
            {
                _pLost.GetComponent<AudioSource>().mute = true;
               
                _musicLock.gameObject.SetActive(true);
            }
            else
            {
                _pLost.GetComponent<AudioSource>().mute = false;
                
                _musicLock.gameObject.SetActive(false);
            }
            if (PlayerPrefs.GetInt("SoundEff") == _soundEffOFF)             //отключение зыуковых эффектов
            {
                _p1effectLost.GetComponent<AudioSource>().mute = true;

                _soundEffLock.gameObject.SetActive(true);
                foreach (ParticleSystem partikl in particles)
                {
                    partikl.GetComponent<AudioSource>().mute = true;
                }
            }

            else
            {
                _p1effectLost.GetComponent<AudioSource>().mute = false;

                _soundEffLock.gameObject.SetActive(false);

                foreach (ParticleSystem partikl in particles)
                {
                    partikl.GetComponent<AudioSource>().mute = false;
                }
            }
        }        
        public void ExitGamePanel()
        {
            if (_lockFunc != true)
            {
                if (_exitMenu.transform.position.y < 0)
                {
                    _lockFunc = true;
                    Time.timeScale = 0;
                    _tween = _exitMenu.transform.DOMove(new Vector3(0, 0, 0), 1f, true).SetEase(Ease.InOutBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                       
                    });
                    foreach (Button button in _button)
                    {
                        button.gameObject.SetActive(false);
                    }
                }
                else
                {
                    _lockFunc = true;
                    Time.timeScale = 1;
                    _tween = _exitMenu.transform.DOMove(new Vector3(0, - 11, 0), 1f, true).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                        foreach (Button button in _button)
                        {
                            button.gameObject.SetActive(true);
                        }
                    });                    
                }
            }
        }

        public void SettingsPanel()
        {
            if (_lockFunc != true)
            {
                if (_setMenu.transform.position.y < 0)
                {
                    _lockFunc = true;
                    Time.timeScale = 0;
                    _tween = _setMenu.transform.DOMove(new Vector3(0, 0, 0), 1f, true).SetEase(Ease.InOutBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                        
                    });
                    foreach (Button button in _button)
                    {
                        button.gameObject.SetActive(false);
                    }
                }
                else
                {
                    _lockFunc = true;
                    Time.timeScale = 1;
                    _tween = _setMenu.transform.DOMove(new Vector3(0, -11, 0), 1f, true).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
                    {
                        _lockFunc = false;
                        foreach (Button button in _button)
                        {
                            button.gameObject.SetActive(true);
                        }
                    });                    
                }
            }
        }        

        private void OnDisable()
        {
            _setMenu.transform.DOKill();
            _exitMenu.transform.DOKill();
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.Save();
        }
    }
}