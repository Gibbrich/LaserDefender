using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CombatBehaviour
{
    public float ShotsPerSecond = 0.5f;

    protected override void Shoot()
    {
        float probability = ShotsPerSecond * Time.deltaTime;
        if (Random.value < probability)
        {
            GameObject laserShoot = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 0.75f),
                Quaternion.identity);
            laserShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
        }
    }
}