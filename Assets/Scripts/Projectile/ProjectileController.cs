using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour, IPoolable<ProjectileController>
{
    private Action<ProjectileController> ReturnAction;
    [SerializeField] private float _speed;
    private Vector3 _direction;
    private bool _canMove;

    private void OnDisable()
    {
        _canMove = false;
        ReturnToPool();
    }
    private void OnEnable()
    {
        _canMove = true;
    }
    private void Update()
    {
        Move();
    }
    public void Initialize(Action<ProjectileController> returnAction)
    {
        ReturnAction = returnAction;
    }
    public void ReturnToPool()
    {
        ReturnAction?.Invoke(this);
    }
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
    public void Move()
    {
        if (!_canMove) return;
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
