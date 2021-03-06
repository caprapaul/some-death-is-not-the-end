﻿using System;
using System.Collections;
using System.Collections.Generic;
using Movements;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawning
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private float _timeBetweenWaves = 1;
        [SerializeField]
        private List<SpawnedObject> _spawnedObjects;
        [SerializeField]
        private List<Transform> _spawnPoints;

        private int _currentWave = 1;
        private int _aliveCount = 0;
        private IEnumerator _spawnWave;

        public int CurrentWave
        {
            get
            {
                return _currentWave;
            }
        }

        public void Start()
        {
            _spawnWave = SpawnWave();
            StartCoroutine(SpawnWave());
        }

        public void DecreaseAliveCount()
        {
            _aliveCount--;
        }

        private IEnumerator SpawnWave()
        {
            yield return new WaitForSeconds(_timeBetweenWaves);

            int spawnCount = Mathf.CeilToInt(CurrentWave * Mathf.Log(CurrentWave + 1));
            int spawnedCount = 0;
            
            while (spawnedCount < spawnCount)
            {
                int spawnedObjectIndex = Random.Range(0, _spawnedObjects.Count);

                SpawnedObject spawnedObject = _spawnedObjects[spawnedObjectIndex];

                if (CurrentWave > spawnedObject.MinWave)
                {
                    int spawnPointIndex = Random.Range(0, _spawnPoints.Count);
                    Transform spawnPoint = _spawnPoints[spawnPointIndex];

                    GameObject spawnedGameObject = Instantiate(spawnedObject.GameObject, spawnPoint.position, Quaternion.identity);
                    Health health = spawnedGameObject.GetComponent<Health>();
                    spawnedGameObject.GetComponent<MovementHandler>().Speed = Random.Range(1.8f, 3.2f);
                    
                    health.OnDeath.AddListener(DecreaseAliveCount);
                    
                    _aliveCount++;
                    spawnedCount++;
                }
            }

            while (_aliveCount > 0)
            {
                yield return null;
            }

            _currentWave = CurrentWave + 1;

            StartCoroutine(SpawnWave());
        }

        [Serializable]
        private class SpawnedObject
        {
            public GameObject GameObject;
            public int MinWave;
        }
    }
}