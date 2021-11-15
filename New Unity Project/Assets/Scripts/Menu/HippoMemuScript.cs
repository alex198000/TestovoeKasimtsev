using Spine.Unity;
using UnityEngine;

namespace Menu
{
    public class HippoMemuScript : MonoBehaviour
    {
        [SerializeField] protected SkeletonAnimation _animPerson;
        void Start()
        {
            float timeAnimIdl = _animPerson.skeleton.Data.FindAnimation("Idle").Duration;
            float timeAnimApl = _animPerson.skeleton.Data.FindAnimation("Applause").Duration;
            float timeAnimShoot = _animPerson.skeleton.Data.FindAnimation("shoot").Duration;
            float timeAnimIdl3 = _animPerson.skeleton.Data.FindAnimation("Idle3").Duration;
            float timeAnimIdl4 = _animPerson.skeleton.Data.FindAnimation("Idle4").Duration;
            _animPerson.state.SetAnimation(0, "Idle", true);
            _animPerson.state.AddAnimation(0, "Applause", true, timeAnimIdl);            
            _animPerson.state.AddAnimation(0, "shoot", true, timeAnimApl);
            _animPerson.state.AddAnimation(0, "Idle3", true, timeAnimShoot);
            _animPerson.state.AddAnimation(0, "Idle4", true, timeAnimIdl3);
            _animPerson.state.AddAnimation(0, "Idle5", true, timeAnimIdl4);
        }       
    }
}