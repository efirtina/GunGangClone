using UnityEngine;

public class SoldierFiring : MonoBehaviour
{
    [SerializeField] private float _firingRate;
    [SerializeField] private Transform _gunTransform;
    private float _shootTimer;
    private float Cooldown
    {
        get
        {
            return 1 / _firingRate;
        }
    }

    public void ResetShootTimer()
    {
        _shootTimer = 0;
    }

    public void SetShootTimer(float value)
    {
        _shootTimer = value;
    }

    public void DoCountdown()
    {
        _shootTimer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (_shootTimer > 0) return;
        ProjectileManager.Instance.PullProjectile(_gunTransform.position);
        _shootTimer = Cooldown;
    }
}