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

        private void OnEnable()
        {
            _hpPersons = _health;
            Timer.OnEndGame += StopAllCoroutines;
            LevelManager.OnWinGame += StopAllCoroutines;
            OnDeathGippo += StopAllCoroutines;
        }
        private void OnDisable()
        {
            Timer.OnEndGame -= StopAllCoroutines;
            LevelManager.OnWinGame -= StopAllCoroutines;
            OnDeathGippo -= StopAllCoroutines;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            SnowBallScript snowBallScript = col.gameObject.GetComponent<SnowBallScript>();
           
            if (snowBallScript != null)                         // ������������ � �������
            {
                if(_isEmemy == true && snowBallScript.IsEnemyShot != true)
                {
                    _hpPersons -= snowBallScript.DamageSnowBall;
                    
                    if (_hpPersons <= 0)
                    {                        
                        _hpPersons = _health;
                        _scoreControl.Score += _bonus;
                        OnHitEnemy?.Invoke();
                        if(gameObject.active) StartCoroutine(WoundedEnemy());
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

        private IEnumerator WoundedEnemy()
        {            
          _enemyScript.EnemyWounded();
          yield return new WaitForSeconds(1f);           
            
          StartCoroutine(DeadEnemy());
          yield return new WaitForFixedUpdate();
        }

        private IEnumerator DeadEnemy()
        {            
            _enemyScript.EnemyDeath();
            
            yield return new WaitForFixedUpdate();           
        }  
        //void StopCorutines()
        //{
        //    StopCoroutine(WoundedEnemy());
        //    StopCoroutine(DeadEnemy());
        //}
    }
}
