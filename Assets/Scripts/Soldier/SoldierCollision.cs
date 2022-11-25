using System;
using UnityEngine;

public class SoldierCollision : MonoBehaviour
{
    private Action<Collider> TriggerEnter;
    private Action<Collision> CollisionEnter;

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
}
