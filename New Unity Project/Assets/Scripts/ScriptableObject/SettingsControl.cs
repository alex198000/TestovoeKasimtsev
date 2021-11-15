using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    [CreateAssetMenu(fileName = "SettingsControl", menuName = "ScriptableObjects/NewSettingsControl")]
    public class SettingsControl : ScriptableObject
    {
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

        public void OnEnable()
        {
            _min = PlayerPrefs.GetInt("Min");
            _speedEnemy = PlayerPrefs.GetFloat("SpeedEnemy");
            _gippoSpeed = PlayerPrefs.GetFloat("GippoSpeed");
            _scoreToWin = PlayerPrefs.GetInt("ScoreToWin");
            _scoreToHitEnemy = PlayerPrefs.GetInt("ScoreToHitEnemy");
            _speedRate = PlayerPrefs.GetFloat("SpeedRate");
            _speedEnemyAttack = PlayerPrefs.GetFloat("SpeedEnemyAttack");
        }
    }
}