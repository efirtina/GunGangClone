using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance;
    [SerializeField] private ProjectileController _prefab;
    [SerializeField] private int _poolSize;
    public ObjectPool<ProjectileController> ProjectilePool { get; private set; }

    private void Awake()
    {
        Instance = this;
        ProjectilePool = new ObjectPool<ProjectileController>(_prefab, _poolSize, OnPull, OnPush);
    }

    public void OnPush(ProjectileController projectile)
    {

    }
    public void OnPull(ProjectileController projectile)
    {

    }
}