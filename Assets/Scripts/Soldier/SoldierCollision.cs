using System;
using UnityEngine;

public class SoldierCollision : MonoBehaviour
{
    private Collider _collider;
    private Action<Collider> TriggerEnter;
    private Action<Collision> CollisionEnter;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter?.Invoke(collision);
    }

    public void SetTriggerEnter(Action<Collider> action)
    {
        TriggerEnter = action;
    }

    public void SetCollisionEnter(Action<Collision> action)
    {
        CollisionEnter = action;
    }

    public void SetIsTrigger(bool value)
    {
        _collider.isTrigger = value;
    }
}
