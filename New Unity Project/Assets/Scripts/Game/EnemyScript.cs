using Spine.Unity;
using UnityEngine;

namespace Game
{
    public class EnemyScript : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _skeleton;
        [SerializeField] private ParticleSystem _hitParticle;
        [SerializeField] private PersonsHealth _enemyHealth;
        [SerializeField] private BoxCollider2D _colider;
        [SerializeField] private EnemyProperty _enemyProperty;
        [SerializeField] private EnemyMoove _enemyMoove;
        [SerializeField] private bool _enemyStateOn = false;
        [SerializeField] private bool _enemyStateOff = false;

        public bool EnemyStateOn { get => _enemyStateOn; set => _enemyStateOn = value; }
        public bool EnemyStateOff { get => _enemyStateOff; set => _enemyStateOff = value; }

        private void Awake()
        {
            _colider = GetComponent<BoxCollider2D>();
            _skeleton = GetComponentInChildren<SkeletonAnimation>();
            _enemyHealth = GetComponent<PersonsHealth>();                     
        }

        private void OnEnable()
        {
            Timer.OnEndGame += EnemyDeactiv;
            LevelManager.OnWinGame += EnemyDeactiv;
            PersonsHealth.OnDeathGippo += EnemyDeactiv;
            _enemyStateOn = false;
            _enemyStateOff = false;
        }

        private void OnDisable()
        {
            Timer.OnEndGame -= EnemyDeactiv;
            LevelManager.OnWinGame -= EnemyDeactiv;
            PersonsHealth.OnDeathGippo -= EnemyDeactiv;            
        }

        public void SetPropertyToEnemy(EnemyProperty enemyProperty)             // форммируем врага
        {
            this._enemyProperty = enemyProperty;
            transform.localScale = new Vector3(enemyProperty.ScaleEnemy.x, enemyProperty.ScaleEnemy.y, enemyProperty.ScaleEnemy.z);
            _enemyHealth.HpMax = enemyProperty.EnemyHealth;
            _enemyHealth.HpPersons = _enemyHealth.HpMax;
            _colider.size = enemyProperty.EnemyColl;
            _hitParticle = enemyProperty.ParticleHit;
            _enemyHealth.Bonus = enemyProperty.Bonus;
            _skeleton.initialSkinName = enemyProperty.InitialSkin;                             //смена скина врага
            _skeleton.Skeleton.SetSkin(enemyProperty.InitialSkin);            
        }    
        void EnemyDeactiv()
        {
            gameObject.SetActive(false);
        }

        public void EnemyDeath()                  // улет врага вправо за экран
        {
            _hitParticle.Play();
            _enemyStateOn = false;
            _enemyStateOff = true;
            _enemyMoove.SpeedEnemy *= 20;
            _enemyMoove.Diraction = new Vector3(_enemyMoove.Right, _enemyMoove.Diraction.y, _enemyMoove.Diraction.z);
        }
    }
}