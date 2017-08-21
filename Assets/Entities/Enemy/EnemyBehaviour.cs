using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CombatBehaviour
{
    public int Score = 50;
    public float ShotsPerSecond = 0.5f;

    private ScoreKeeper scoreKeeper;

    protected override void Shoot()
    {
        float probability = ShotsPerSecond * Time.deltaTime;
        if (Random.value < probability)
        {
            GameObject laserShoot = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y - 0.75f),
                Quaternion.identity);
            laserShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ProjectileSpeed);
            source.Play();
        }
    }

    protected override void Start()
    {
        base.Start();
        
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        OnDestroyHandler += () =>
        {
            AudioSource.PlayClipAtPoint(explosionSFX, transform.position);
            scoreKeeper.Score(Score);
        };
    }
}