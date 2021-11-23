using UnityEngine;

namespace Game
{
    public class SnowBallScript : MonoBehaviour
    {        
        [SerializeField] private int _damageSnowBall = 1;        
        [SerializeField] private float _speedSnowBall;
        [SerializeField] private float _speedSnowBallEnemy;        
        [SerializeField] private bool _isEnemyShot = false;

        [SerializeField] private Rigidbody2D _rbSnowBall;
        [SerializeField] private SnowBallProperty _snowBallProperty;

        public int DamageSnowBall { get => _damageSnowBall; set => _damageSnowBall = value; }
        public bool IsEnemyShot { get => _isEnemyShot; set => _isEnemyShot = value; }
        public float SpeedSnowBall { get => _speedSnowBall; set => _speedSnowBall = value; }

        private void OnEnable()
        {

            _speedSnowBall = _snowBallProperty.SpeedSnowBallValue;

            if (_isEnemyShot)
            {
                _rbSnowBall.AddForce(transform.right * _speedSnowBallEnemy);
            }                
                
            if (_isEnemyShot == false)
            {
                _rbSnowBall.AddForce(transform.right * _speedSnowBall); 
            }

            Timer.OnEndGame += SnowDeactiv;
            LevelManager.OnWinGame += SnowDeactiv;
            PersonsHealth.OnDeathGippo += SnowDeactiv;
        }

        private void OnDisable()
        {
            Timer.OnEndGame -= SnowDeactiv;
            LevelManager.OnWinGame -= SnowDeactiv;            
            PersonsHealth.OnDeathGippo -= SnowDeactiv;
        }
        private void OnTriggerEnter2D(Collider2D coll)
        {
            EnemyScript enemyMoove = coll.gameObject.GetComponent<EnemyScript>();
            CharacterControl characterControl = coll.gameObject.GetComponent<CharacterControl>();
            BarierSnowScript barierSnowScript = coll.gameObject.GetComponent<BarierSnowScript>();

            if ((enemyMoove != null && _isEnemyShot == false) || (characterControl != null && _isEnemyShot) || barierSnowScript != null)
            {
                SnowDeactiv();
            }
        }

        public void SetPropertyToSnowBall(SnowBallProperty snowballProperty)            
        {
            this._snowBallProperty = snowballProperty;

            _speedSnowBall = snowballProperty.SpeedSnowBallValue;           
        }
        void SnowDeactiv()
        {
            gameObject.SetActive(false);
        }
    }
}
