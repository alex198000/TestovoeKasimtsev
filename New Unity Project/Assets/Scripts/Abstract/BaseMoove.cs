using Spine.Unity;
using UnityEngine;

namespace Game
{
    public abstract class BaseMoove : MonoBehaviour
    {
        [SerializeField] protected SkeletonAnimation _animPerson;
        protected abstract void Attack();
        

        protected abstract void Walk();
        

        protected abstract void Idle();
        
    }
}