using System;
using UnityEngine;

public abstract class CombatBehaviour : MonoBehaviour
{
    public float Health = 150;
    public GameObject Projectile;
    public AudioClip explosionSFX;
    public float ProjectileSpeed;

    protected Action OnDestroyHandler;
    protected AudioSource source;

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
                if (OnDestroyHandler != null)
                {
                    OnDestroyHandler();
                }
                
                Destroy(gameObject);
            }
        }
    }

    protected virtual void Start()
    {
        source = GetComponent<AudioSource>();
    }
}