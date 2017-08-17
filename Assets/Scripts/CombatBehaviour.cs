using UnityEngine;

public abstract class CombatBehaviour : MonoBehaviour
{
    public float Health = 150;
    public GameObject Projectile;
    public float ProjectileSpeed;

    protected void TakeHit(Projectile missle)
    {
        Health -= missle.Damage;
        missle.Hit();
            
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void Shoot();
}