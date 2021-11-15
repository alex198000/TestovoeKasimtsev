using Spine.Unity;
using UnityEngine;

namespace Game
{
    public class SpineEnemy : MonoBehaviour
    {        
        [SerializeField] protected SkeletonAnimation _animEnemy;

        public void OnEnable()
        {
            float timeAnime = _animEnemy.skeleton.Data.FindAnimation("Idle").Duration;
            _animEnemy.state.SetAnimation(0, "Idle", false);
            _animEnemy.state.AddAnimation(0, "Applause", true, timeAnime);
        }
    }
}