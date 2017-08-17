using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CombatBehaviour
{
    public float FiringRateMin = 1f;
    public float FiringRateMax = 3f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerProjectile missle = other.GetComponent<PlayerProjectile>();
        if (missle)
        {
            TakeHit(missle);
        }
    }

    protected override void Shoot()
    {
        InvokeRepeating("Fire", Random.Range(0.5f, 2f), Random.Range(FiringRateMin, FiringRateMax));
    }

    private void Start()
    {
        Shoot();
    }

    private void Fire()
    {
        GameObject laserShoot = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 0.75f),
            Quaternion.identity);
        laserShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
    }
}