using Spine.Unity;
using UnityEngine;

namespace Game
{
    public abstract class BaseMoove : MonoBehaviour
    {
        [SerializeField] protected SkeletonAnimation _animPerson;
        [SerializeField] protected string _particleTag;
        protected abstract void Attack();

        protected abstract void Wounded();


        protected abstract void Walk();
        

        protected abstract void Idle();
        
    }
}