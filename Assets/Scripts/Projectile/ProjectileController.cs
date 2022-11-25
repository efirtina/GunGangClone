using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour, IPoolable<ProjectileController>
{
    private Action<ProjectileController> ReturnAction;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    private float _timer;
    private Vector3 _direction;
    private bool _canMove;

    private void OnDisable()
    {
        _canMove = false;
        _timer = _lifeTime;
        ReturnToPool();
    }

    private void OnEnable()
    {
        _canMove = true;
    }

    private void Start()
    {
        _direction = Vector3.forward;
        _timer = _lifeTime;
    }

    private void Update()
    {
        DoCountdown();
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

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void Move()
    {
        if (!_canMove) return;
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void DoCountdown()
    {
        _timer -= Time.deltaTime;
        if(_timer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
