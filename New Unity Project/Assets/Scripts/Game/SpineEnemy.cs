using UnityEngine;

namespace Game
{
    public class SpineEnemy : BaseMoove
    { 
        [SerializeField] private GameObject _actors;        

        protected override void Idle()
        {
            _animPerson.state.SetAnimation(0, "Idle", true);
        }
        protected override void Walk()
        {
            _animPerson.state.SetAnimation(0, "walk", true);
            _actors.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        protected override void Attack()
        {
            float timeAnim = _animPerson.skeleton.Data.FindAnimation("Applause").Duration;
            _animPerson.state.SetAnimation(0, "Applause", false);
            _animPerson.state.AddAnimation(0, "Idle", true, timeAnim);
        }

        protected override void Wounded()
        {
            float timeAnimWoundEnem = _animPerson.skeleton.Data.FindAnimation("wake_up").Duration;
            _animPerson.state.SetAnimation(0, "wake_up", false);
            _animPerson.state.AddAnimation(0, "Idle", true, timeAnimWoundEnem);
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
    }
}