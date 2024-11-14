using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerSpace
{
    public class PoolObject : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToPool;
        [SerializeField] internal Transform spawnObject;
        [SerializeField] private List<GameObject> _poolObjects;
        [SerializeField] private int _maxPoolSize = 5;

        private void Awake()
        {
            
            AddBulletToPool(_maxPoolSize);
        }

        private void AddBulletToPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject poolTemp = Instantiate(_objectToPool, spawnObject);
                poolTemp.SetActive(false);
                _poolObjects.Add(poolTemp);
            }
        }

        internal GameObject GetPoolObject()
        {
            foreach (var enemyObject in _poolObjects.Where(enemyObject => !enemyObject.activeInHierarchy))
            {
                return enemyObject;
            }

            GameObject poolTemp = Instantiate(_objectToPool, spawnObject);
            poolTemp.SetActive(false);
            _poolObjects.Add(poolTemp);

            return poolTemp;
        }
    }
}