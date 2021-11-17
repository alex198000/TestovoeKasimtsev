using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class UISettings : MonoBehaviour
    {
        [SerializeField] private SettingsControl _settingsControl;

        [SerializeField] private InputField _minInput;
        [SerializeField] private InputField _speedEnemyInput;
        [SerializeField] private InputField _gippoSpeedInput;
        [SerializeField] private InputField _scoreToWinInput;
        [SerializeField] private InputField _scoreToHitEnemyInput;
        [SerializeField] private InputField _speedRateInput;
        [SerializeField] private InputField _speedEnemyAttackInput;

        public InputField MinText { get => _minInput; set => _minInput = value; }
        public InputField SpeedEnemyText { get => _speedEnemyInput; set => _speedEnemyInput = value; }
        public InputField GippoSpeedText { get => _gippoSpeedInput; set => _gippoSpeedInput = value; }
        public InputField ScoreToWinText { get => _scoreToWinInput; set => _scoreToWinInput = value; }
        public InputField ScoreToHitEnemyText { get => _scoreToHitEnemyInput; set => _scoreToHitEnemyInput = value; }
        public InputField SpeedRateText { get => _speedRateInput; set => _speedRateInput = value; }
        public InputField SpeedEnemyAttackText { get => _speedEnemyAttackInput; set => _speedEnemyAttackInput = value; }

       
        [SerializeField] private int _min;
        [SerializeField] private float _speedEnemy;
        [SerializeField] private float _gippoSpeed;
        [SerializeField] private int _scoreToWin;
        [SerializeField] private int _scoreToHitEnemy;
        [SerializeField] private float _speedRate;
        [SerializeField] private float _speedEnemyAttack;

        public int Min { get => _min; set => _min = value; }
        public float SpeedEnemy { get => _speedEnemy; set => _speedEnemy = value; }
        public float GippoSpeed { get => _gippoSpeed; set => _gippoSpeed = value; }
        public int ScoreToWin { get => _scoreToWin; set => _scoreToWin = value; }
        public int ScoreToHitEnemy { get => _scoreToHitEnemy; set => _scoreToHitEnemy = value; }
        public float SpeedRate { get => _speedRate; set => _speedRate = value; }
        public float SpeedEnemyAttack { get => _speedEnemyAttack; set => _speedEnemyAttack = value; }

        public void Awake()
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
            if (!PlayerPrefs.HasKey("Min"))       //активация настроек по умолчанию
            {
                PlayerPrefs.SetInt("Min", 10);
                _settingsControl.Min = PlayerPrefs.GetInt("Min");
            }
            if (!PlayerPrefs.HasKey("SpeedEnemy"))
            {
                PlayerPrefs.SetFloat("SpeedEnemy", 2.2f);
                _settingsControl.SpeedEnemy = PlayerPrefs.GetFloat("SpeedEnemy");
            }
            if (!PlayerPrefs.HasKey("GippoSpeed"))
            {
                PlayerPrefs.SetFloat("GippoSpeed", 2.5f);
                _settingsControl.GippoSpeed = PlayerPrefs.GetFloat("GippoSpeed");
            }
            if (!PlayerPrefs.HasKey("ScoreToWin"))
            {
                PlayerPrefs.SetInt("ScoreToWin", 10);
                _settingsControl.ScoreToWin = PlayerPrefs.GetInt("ScoreToWin");
            }
            if (!PlayerPrefs.HasKey("ScoreToHitEnemy"))
            {
                PlayerPrefs.SetInt("ScoreToHitEnemy", 2);
                _settingsControl.ScoreToHitEnemy = PlayerPrefs.GetInt("ScoreToHitEnemy");
            }
            if (!PlayerPrefs.HasKey("SpeedRate"))
            {
                PlayerPrefs.SetFloat("SpeedRate", 2.0f);
                _settingsControl.SpeedRate = PlayerPrefs.GetFloat("SpeedRate");
            }
            if (!PlayerPrefs.HasKey("SpeedEnemyAttack"))
            {
                PlayerPrefs.SetFloat("SpeedEnemyAttack", 5.5f);
                _settingsControl.SpeedEnemyAttack = PlayerPrefs.GetFloat("SpeedEnemyAttack");
            }

            _min = _settingsControl.Min;
            _speedEnemy = _settingsControl.SpeedEnemy;
            _gippoSpeed = _settingsControl.GippoSpeed;
            _scoreToWin = _settingsControl.ScoreToWin;
            _scoreToHitEnemy = _settingsControl.ScoreToHitEnemy;
            _speedRate = _settingsControl.SpeedRate;
            _speedEnemyAttack = _settingsControl.SpeedEnemyAttack;
        }
    }
}