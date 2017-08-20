using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float damage = 100f;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}