using System;
using UnityEngine;

public class SoldierCollision : MonoBehaviour
{
    private Collider _collider;
    private Action<Collider> TriggerStay;
    private Action<Collision> CollisionEnter;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //TriggerEnter?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStay?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter?.Invoke(collision);
    }

    public void SetTriggerStay(Action<Collider> action)
    {
        TriggerStay = action;
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
