using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "EnemyProperty", menuName = "ScriptableObjects/NewEnemyProperty")]
    public class EnemyProperty : ScriptableObject
    {       
        [SerializeField] private string initialSkin;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private int _bonus;
        [SerializeField] private int _enemyHealth;
        [SerializeField] private Vector3 _enemyScale;
        [SerializeField] private Vector2 _enemyColl;       

        public float SpeedEnemy
        {
            get
            {
                return _enemySpeed;
            }
        }
        public Vector3 ScaleEnemy
        {
            get
            {
                return _enemyScale;
            }
        }
        public string InitialSkin
        {
            get
            {
                return initialSkin;
            }
        }

        public int Bonus
        {
            get
            {
                return _bonus;
            }
        }
        public int EnemyHealth
        {
            get
            {
                return _enemyHealth;
            }
        }
        public Vector2 EnemyColl
        {
            get
            {
                return _enemyColl;
            }
        }      
    }
}


