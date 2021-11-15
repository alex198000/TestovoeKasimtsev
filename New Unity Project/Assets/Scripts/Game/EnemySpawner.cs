using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private string _enemyTag;
        [SerializeField] private Transform _enemyManager;
        [SerializeField] private List<EnemyProperty> _enemyProperties;
        [SerializeField] private List<Transform> _enemySpawnPoint;
        [SerializeField] private int _waveCount;
        [SerializeField] private int _enemyCount;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float waveRate;
               
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }        

        void ActiveEnemy()
        {
            GameObject enemy = ObjectPooler.objectPooler.GetPooledObject(_enemyTag);
            if (enemy != null)
            {
                Transform _sp = _enemySpawnPoint[Random.Range(0, _enemySpawnPoint.Count)];
                enemy.transform.position = _sp.position;

                enemy.SetActive(true);
                enemy.transform.SetParent(_enemyManager);

                int randomEnemyPropertyIndex = Random.Range(0, _enemyProperties.Count);
                enemy.GetComponent<EnemyScript>().SetPropertyToEnemy(_enemyProperties[randomEnemyPropertyIndex]);
            }
        }
        IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(_spawnRate);      //ожидание перед волной
            while (_waveCount > 0)
            {
                for (int i = 0; i < _enemyCount; i++)
                {
                    yield return new WaitForSeconds(_spawnRate);
                    ActiveEnemy();
                }             
                yield return new WaitForSeconds(waveRate);        // ожидание перед сл волной
            }
        }
    }
}