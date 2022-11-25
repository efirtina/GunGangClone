using System;
using UnityEngine;

public class SoldierCollision : MonoBehaviour
{
    public Action<Collider> TriggerEnter;
    public Action<Collision> CollisionEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnter?.Invoke(collision);
    }
}
