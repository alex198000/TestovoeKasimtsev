using UnityEngine;

namespace Game
{
    public class SpinePersons : BaseMoove
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

        private void GippoWin()
        {
            _animPerson.state.SetAnimation(0, "joy_jump", true);
            Debug.Log("Win");
        }
        private void GippoDefeat()
        {
            _animPerson.state.SetAnimation(0, "joy", true);
            Debug.Log("Def");
        }       
    }
}

