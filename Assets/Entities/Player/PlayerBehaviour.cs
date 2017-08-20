using UnityEngine;

public class PlayerBehaviour : CombatBehaviour
{
    public float FiringRate = 0.2f;

    protected override void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0, FiringRate);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }

    private void Fire()
    {
        GameObject laserShoot = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y + 0.75f),
            Quaternion.identity);
        laserShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ProjectileSpeed);
    }
}