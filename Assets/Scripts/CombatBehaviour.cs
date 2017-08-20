using UnityEngine;

public abstract class CombatBehaviour : MonoBehaviour
{
    public float Health = 150;
    public GameObject Projectile;
    public float ProjectileSpeed;

    protected abstract void Shoot();

    protected virtual void Update()
    {
        Shoot();
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        Projectile missle = other.GetComponent<Projectile>();
        if (missle)
        {
            Health -= missle.Damage;
            missle.Hit();
        
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}