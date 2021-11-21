﻿using UnityEngine;

namespace Game
{
    public class HippoMoove : BaseMoove
    {
        [SerializeField] private GameObject _actors;       

        private void Start()
        {
            Idle();
        }
        protected override void Idle()
        {
            _animPerson.state.SetAnimation(0, "Idle", true);
        }
        protected override void Walk()
        {
            _animPerson.state.SetAnimation(0, "walk", true);
        }
        protected override void Attack()
        {
            float timeAnim = _animPerson.skeleton.Data.FindAnimation("shoot").Duration;
            _animPerson.state.SetAnimation(0, "shoot", false);
            _animPerson.state.AddAnimation(0, "Idle", true, timeAnim);
        }

        public void RightMove()
        {
            Walk();
            _actors.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        public void LeftMove()
        {
            Walk();
            _actors.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        public void UpMove()
        {
            Walk();
        }

        public void DownMove()
        {
            Walk();
        }

        public void StopMove()
        {
            Idle();
        }                    
    }
}
