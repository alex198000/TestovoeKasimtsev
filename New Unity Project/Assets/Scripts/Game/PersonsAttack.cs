using System;
using UnityEngine;

namespace Game
{
    public class PersonsAttack : MonoBehaviour
    {
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private SnowBallProperty _snowBallProperty; 
        [SerializeField] private float _fireRate;  
        [SerializeField] private float _nextFire;
        [SerializeField] private Transform _snowBallManager;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private string _snowBallTag;
        [SerializeField] private bool _enemyAttack;

        public float FireRate { get => _fireRate; set => _fireRate = value; }
        public float NextFire { get => _nextFire; set => _nextFire = value; }

        public static event Action OnShotHippo;
        public static event Action OnShotEnemy;
        private void Start()
        {
            if(_enemyAttack != true)
            {
                _fireRate = _settingsControl.SpeedRate;
                _nextFire = _fireRate;
            }
            else
            {
                _fireRate = _settingsControl.SpeedEnemyAttack;
                _nextFire = _fireRate;
            }
        }
        private void FixedUpdate()
        {
            _nextFire += Time.deltaTime;
        }

        public void Fire(bool isEnemy, float grav)
        {            
            if (_nextFire > _fireRate)
            {
                
                GameObject SnowBall = ObjectPooler.objectPooler.GetPooledObject(_snowBallTag);
                if (SnowBall != null)
                {
                    SnowBall.GetComponent<SnowBallScript>().IsEnemyShot = isEnemy;
                    SnowBall.GetComponent<Rigidbody2D>().gravityScale = grav;                 
                    SnowBall.transform.position = _spawnPoint.position;
                    SnowBall.transform.rotation = _spawnPoint.rotation;                   
                    SnowBall.GetComponent<SnowBallScript>().SetPropertyToSnowBall(_snowBallProperty);
                    SnowBall.SetActive(true);
                    SnowBall.transform.SetParent(_snowBallManager);
                    _nextFire = 0;                    
                }
                if (isEnemy == false) OnShotHippo?.Invoke();
                else OnShotEnemy?.Invoke();
            }            
        }
    }
}