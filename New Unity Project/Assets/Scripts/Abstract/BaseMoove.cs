using Spine.Unity;
using UnityEngine;

namespace Game
{
    public abstract class BaseMoove : MonoBehaviour
    {
        [SerializeField] protected SkeletonAnimation _animPerson;
        protected virtual void Attack()
        {
            _animPerson.state.SetAnimation(0, "shoot", true);
        }

        protected abstract void Walk();
        

        protected abstract void Idle();
        
    }
}