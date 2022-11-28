using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    private List<EnemyController> _enemies;
    [SerializeField] private int _numberOfEnemiesToSpawn;
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    private WaitForSeconds _coolDown;
    public Action OnAllEnemiesKilled;
    private int _numberOfEnemiesKilled;
    public int NumberOfEnemiesKilled
    {
        get
        {
            return _numberOfEnemiesKilled;
        }
        set
        {
            _numberOfEnemiesKilled = value;
            if(_numberOfEnemiesKilled == _numberOfEnemiesToSpawn)
            {
                OnAllEnemiesKilled?.Invoke();
            }
        }
    }

    private void OnEnable()
    {
        SoldierManager.Instance.OnEverySoldierGotCover += Spawn;
    }

    private void OnDisable()
    {
        SoldierManager.Instance.OnEverySoldierGotCover -= Spawn;
    }

    private void Awake()
    {
        Instance = this;
        _enemies = new List<EnemyController>();
    }

    private void Start()
    {
        _coolDown = new WaitForSeconds(_spawnDelay);
    }

    private void Spawn()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < _numberOfEnemiesToSpawn; i++)
        {
            var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.Euler(0,180f,0));
            enemy.OnSpawn(i % 2);
            _enemies.Add(enemy);

            yield return _coolDown;
        }
    }
    public void RemoveEnemyFromList(EnemyController enemy)
    {
        _enemies.Remove(enemy);
    }
    public void OnEnemyKilled()
    {
        NumberOfEnemiesKilled += 1;
    }
    public Vector3 GetNextEnemyPosition()
    {
        if (_enemies.Count < 1) 
        {
            return transform.position; 
        }
        return _enemies[0].transform.position;
    }
    public Vector3 GetNextEnemyMovingDirection()
    {
        if(_enemies.Count < 1)
        {
            return Vector3.zero;
        }
        return _enemies[0].GetMovingDirection();
    }
}
