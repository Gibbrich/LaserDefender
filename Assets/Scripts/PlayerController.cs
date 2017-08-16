using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementController
{
    public GameObject Projectile;
    public float ProjectileSpeed;
    public float FiringRate = 0.2f;
    
    protected override void Move()
    {
        Vector3 deltaHorizontal = new Vector3(Input.GetAxisRaw("Horizontal") * MovementSpeed * Time.deltaTime, 0);
        Vector3 newPosition = transform.position + deltaHorizontal;
        newPosition.x = Mathf.Clamp(newPosition.x, xMin + width, xMax - width);

        transform.position = newPosition;
    }

    protected override void CalculateWidth()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        width = player.GetComponent<SpriteRenderer>().bounds.max.x;
    }

    protected override void Update()
    {
        base.Update();

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