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
    public Vector3 GetGunPosition()
    {
        return _gunTransform.position;
    }
    public float GetGunYPosition()
    {
        return _gunTransform.position.y;
    }
    public void Shoot()
    {
        if (_shootTimer > 0) return;
        if (!Input.GetKey(KeyCode.Space)) return;
        ProjectileManager.Instance.PullProjectile(_gunTransform.position, out ProjectileController projectile);
        _shootTimer = Cooldown;
    }
    public void Shoot(Vector3 direction)
    {
        if (_shootTimer > 0) return;
        ProjectileManager.Instance.PullProjectile(_gunTransform.position, out ProjectileController projectile);
        projectile.SetDirection(direction);
        _shootTimer = Cooldown;
    }
}
