using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    [SerializeField] private int _numberOfEnemiesToSpawn;
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private float _spawnDelay;
    private WaitForSeconds _coolDown;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _coolDown = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < _numberOfEnemiesToSpawn; i++)
        {
            var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            enemy.OnSpawn(i % 2);

            yield return _coolDown;
        }
    }
}
