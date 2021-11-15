using UnityEngine;

namespace Game
{
    public class BarierScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D coll)
        {
            EnemyScript enemyScript = coll.gameObject.GetComponent<EnemyScript>();
            EnemyMoove enemyMoove = coll.gameObject.GetComponent<EnemyMoove>();

            if (enemyScript != null && enemyScript.EnemyStateOn == true)
            {
                enemyScript.EnemyStateOn = false;
                enemyMoove.Diraction *= -1;
            }            
        }
        private void OnTriggerExit2D(Collider2D coll)
        {
            EnemyScript enemyScript = coll.gameObject.GetComponent<EnemyScript>();
            EnemyMoove enemyMoove = coll.gameObject.GetComponent<EnemyMoove>();

            if (enemyScript != null && enemyScript.EnemyStateOn == false)
            {
                enemyScript.EnemyStateOn = true;              
            }

            if (enemyScript != null && enemyScript.EnemyStateOff == true)
            {
                coll.gameObject.SetActive(false);
            }
        }    
    }
}