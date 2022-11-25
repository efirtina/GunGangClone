using Unity.VisualScripting;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] private int _health;
    public int Health
    {
        get
        {
            return _health;
        }

        set
        {
            if(value > 0)
            {
                _health = value;
            }
            else
            {
                _health = 0;
                Explode();
            }
            OnHealthUpdate();
        }
    }

    protected virtual void Start()
    {

    }

    protected void ReceiveDamage(int value)
    {
        Health -= value;
    }

    protected virtual void Explode()
    {
        Destroy(this.gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            ReceiveDamage(1);
            other.gameObject.SetActive(false);
        }
    }
    protected virtual void OnHealthUpdate()
    {

    }
}
