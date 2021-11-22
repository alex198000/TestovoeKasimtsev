using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class PersonsHealth : BaseActors
    {
        [SerializeField] private int _hpPersons;
        [SerializeField] private ScoreControl _scoreControl;
        [SerializeField] private EnemyScript _enemyScript;
        [SerializeField] private bool _isEmemy = false;

        public int HpMax { get => _health; set => _health = value; }
        public int HpPersons { get => _hpPersons; set => _hpPersons = value; }
        public int Bonus { get => _bonus; set => _bonus = value; }
       
        public static event Action OnHitEnemy;
        public static event Action OnHitGippo;
        public static event Action OnDeathGippo;

        void OnEnable()
        {
            _hpPersons = _health;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            SnowBallScript snowBallScript = col.gameObject.GetComponent<SnowBallScript>();
           
            if (snowBallScript != null)                         // столкновение с снежком
            {
                if(_isEmemy == true && snowBallScript.IsEnemyShot != true)
                {
                    _hpPersons -= snowBallScript.DamageSnowBall;
                    
                    if (_hpPersons <= 0)
                    {
                        StartCoroutine(WoundedEnemy());
                        _hpPersons = _health;
                        _scoreControl.Score += _bonus;
                        OnHitEnemy?.Invoke();
                    }
                }
                if (_isEmemy == false && snowBallScript.IsEnemyShot)
                {
                    _hpPersons -= snowBallScript.DamageSnowBall;
                    OnHitGippo?.Invoke();
                    if (_hpPersons <= 0)
                    {
                        gameObject.SetActive(false);
                        _hpPersons = _health;
                        _scoreControl.Score += _bonus;
                        OnDeathGippo?.Invoke();                       
                    }
                }
            }
        }

        IEnumerator WoundedEnemy()
        {            
          _enemyScript.EnemyWounded();
          yield return new WaitForSeconds(2f);           
            
          StartCoroutine(DeadEnemy());
          yield return new WaitForFixedUpdate();
        }

        IEnumerator DeadEnemy()
        {            
            _enemyScript.EnemyDeath();
            //StopCoroutine(WoundedEnemy());
            //StopCoroutine(DeadEnemy());
            yield return new WaitForFixedUpdate();           
        }
    }
}
