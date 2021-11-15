using UnityEngine;

namespace Game
{
    public abstract class BaseActors : MonoBehaviour
    {
        [SerializeField] protected int _health;
        
        [SerializeField] protected int _bonus;    
    }
}