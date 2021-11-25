using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class EnemyMoove : SpineEnemy
    {
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private Vector3 _diraction;
        [SerializeField] private float _speedEnemy;
        [SerializeField] private double _mooveStop;
        [SerializeField] private double _mooveTrue;
        [SerializeField] private int _left = 1;
        [SerializeField] private int _right = -1;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private bool _stopMoove;
        [SerializeField] private string _particleEnemyTag;
        [SerializeField] private Transform _particleManager;

        System.Random rand = new System.Random();
        public Vector3 Diraction { get => _diraction; set => _diraction = value; }
        public float SpeedEnemy { get => _speedEnemy; set => _speedEnemy = value; }
        public int Left { get => _left; set => _left = value; }
        public int Right { get => _right; set => _right = value; }
        public bool StopMoove { get => _stopMoove; set => _stopMoove = value; }
        public double MooveStop { get => _mooveStop; set => _mooveStop = value; }
        public double MooveTrue { get => _mooveTrue; set => _mooveTrue = value; }

        private void OnEnable()
        {
            //PersonsHealth.OnHitEnemy += StopDeActiv;
            //PersonsHealth.OnHitEnemy += ParticleEnemy;
            _stopMoove = false;
            _diraction.x = _left;
            _speedEnemy = _settingsControl.SpeedEnemy;
            StartCoroutine(MooveOn());
        }

        private void OnDisable()
        {
            //PersonsHealth.OnHitEnemy -= StopDeActiv;
            //PersonsHealth.OnHitEnemy -= ParticleEnemy;
            StopCoroutine(MooveOn());
        }

        private void Start()
        {
            base.Idle();
        }

        public void AttackEnemy()
        {
            base.Attack();
        }

        private void MooveEnemy()
        {
            if (transform.position.x > 0 && _stopMoove != true && _animPerson.AnimationName == "Idle")
            {
               base.Walk();               
            }
            
            transform.Translate(_diraction * _speedEnemy * Time.deltaTime);
        }

        private void IdleEnemy()
        {            
            if (transform.position.x > 0 && _stopMoove == true && _animPerson.AnimationName == "walk")
            {
                base.Idle();
            }            
        }
        IEnumerator MooveOn()
        {
            while (_mooveTrue >= 0)
            {
                MooveEnemy();
                _mooveTrue -= Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            double rc = Convert.ToDouble(rand.Next(40, 80) / 10.0);
            _mooveStop = rc;
            _stopMoove = true;
            StartCoroutine(MooveOff());
            yield return null;
        }

        IEnumerator MooveOff()
        {
            while (_mooveStop >= 0)
            {
               IdleEnemy();
                _mooveStop -= Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }
            double ro = Convert.ToDouble(rand.Next(50, 100) / 10.0);
            _stopMoove = false;
            _mooveTrue = ro; 
            StartCoroutine(MooveOn());
            yield return null;
        }
        //private void StopDeActiv()
        //{
        //    _mooveStop = 0;
        //    //_mooveTrue = 7;
        //}

        public void ParticleEnemy()
        {
                GameObject ParticleEnemy = ObjectPooler.objectPooler.GetPooledObject(_particleEnemyTag);
                if (ParticleEnemy != null)
             {                                 
                ParticleEnemy.transform.position = gameObject.transform.position;
                ParticleEnemy.transform.rotation = gameObject.transform.rotation;
                                    
                ParticleEnemy.SetActive(true);
                ParticleEnemy.GetComponent<ParticleSystem>().Play();
                ParticleEnemy.GetComponent<AudioSource>().Play();
                //ParticleEnemy.transform.SetParent(_particleManager);
                   
             }
                
            
        }
    }
}