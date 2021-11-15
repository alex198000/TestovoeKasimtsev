using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private PersonsAttack _personsAttack;
        [SerializeField] private bool _attackOpen;

        public static event Action OnHitOpen;
        public static event Action OnHitClosed;
        private void OnEnable()
        {
            OnHitClosed += AttackOff;
            OnHitOpen += AttackOn;
            _personsAttack.FireRate = _settingsControl.SpeedEnemyAttack;
            StartCoroutine(FireOn());           
        }
        private void OnDisable()
        {
            OnHitClosed -= AttackOff;
            OnHitOpen -= AttackOn;
        }
        private void EnemyFire()
        {
            if (_personsAttack.NextFire >= _personsAttack.FireRate)   //(Time.time % 5) == 0
            {               
                _personsAttack.Fire(true, 0f);             
                OnHitClosed?.Invoke();               
            }
        }

        IEnumerator FireOn()
        {
            OnHitOpen?.Invoke();
            while (_attackOpen == true)
            {
                EnemyFire();
                yield return new WaitForFixedUpdate();
            }
            StartCoroutine(FireOff());
            yield return null;
        }

        IEnumerator FireOff()
        {
            while (_personsAttack.NextFire <= _personsAttack.FireRate)
            {
                _attackOpen = false;

                yield return new WaitForFixedUpdate();
            }
            StartCoroutine(FireOn());
            yield return null;
        }
        void AttackOn()
        {
            _attackOpen = true;
        }
        void AttackOff()
        {
            _attackOpen = false;
            _personsAttack.NextFire = 0;
        }
    }
}