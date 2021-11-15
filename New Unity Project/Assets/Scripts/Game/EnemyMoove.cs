﻿using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class EnemyMoove : BaseMoove
    {
        [SerializeField] private SettingsControl _settingsControl;
        [SerializeField] private Vector3 _diraction;
        [SerializeField] private float _speedEnemy;
        [SerializeField] private double _mooveStop;
        [SerializeField] private double _mooveTrue;
        [SerializeField] private SpinePersons _spinePersons;
        [SerializeField] private int _left = 1;
        [SerializeField] private int _right = -1;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private bool _stopMoove;


        System.Random rand = new System.Random();
        public Vector3 Diraction { get => _diraction; set => _diraction = value; }
        public float SpeedEnemy { get => _speedEnemy; set => _speedEnemy = value; }
        public int Left { get => _left; set => _left = value; }
        public int Right { get => _right; set => _right = value; }

        public static event Action OnMooveOpen;
        public static event Action OnMooveClosed;

        void OnEnable()
        {
            OnMooveOpen += MooveOpen;
            OnMooveClosed += MooveClosed;
           
            _stopMoove = false;
            _diraction.x = _left;
            _speedEnemy = _settingsControl.SpeedEnemy;
            StartCoroutine(MooveOn());
        }

        private void OnDisable()
        {
            OnMooveOpen -= MooveOpen;
            OnMooveClosed -= MooveClosed;
        }
        void MooveEnemy()
        {           
            if (transform.position.x > 0 && _stopMoove != true)
            {
                _spinePersons.LeftMove();
                transform.Translate(_diraction * _speedEnemy * Time.deltaTime);              
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
                _mooveStop -= Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }
            double ro = Convert.ToDouble(rand.Next(30, 100) / 10.0);
            _stopMoove = false;
            _mooveTrue = ro; 
            StartCoroutine(MooveOn());
            yield return null;
        }
        void MooveOpen()
        {
            double ro = Convert.ToDouble(rand.Next(30, 100) / 10.0);
            _stopMoove = false;
            _mooveTrue = ro; 
        }
        void MooveClosed()
        {
            double rc = Convert.ToDouble(rand.Next(40, 80) / 10.0);
            _stopMoove = true;
            _mooveStop = rc; 
        }

        protected override void Walk()
        {
            _animPerson.state.SetAnimation(0, "walk", true);
        }

        protected override void Idle()
        {
            _animPerson.state.SetAnimation(0, "Idle", true);            
        }
    }
}