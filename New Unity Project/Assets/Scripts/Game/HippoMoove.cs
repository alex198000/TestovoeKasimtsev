using UnityEngine;

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
            float timeAnim = _animPerson.skeleton.Data.FindAnimation("joy").Duration;
            _animPerson.state.SetAnimation(0, "joy", false);
            _animPerson.state.AddAnimation(0, "Idle", true, timeAnim);
        }

        protected override void Wounded()
        {
            float timeAnimWound = _animPerson.skeleton.Data.FindAnimation("wake_up").Duration;
            _animPerson.state.SetAnimation(0, "wake_up", false);
            _animPerson.state.AddAnimation(0, "Idle", true, timeAnimWound);
            GameObject ParticleEnemy = ObjectPooler.objectPooler.GetPooledObject(_particleTag);
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

