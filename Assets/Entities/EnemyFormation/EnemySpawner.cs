using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MovementController
{
    public GameObject enemyPrefab;
    public float EnemySpawnerWidth = 10;
    public float EnemySpawnerHeight = 5;
    public float SpawnDelay = 0.5f;
    
    private bool isMovingRight = false;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }

    protected override void Move()
    {
        if (isMovingRight)
        {
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
        }
        
        float rightEdgeOfFormation = transform.position.x + width / 2;
        float leftEdgeOfFormation = transform.position.x - width / 2;

        if (leftEdgeOfFormation < xMin)
        {
            isMovingRight = true;
        }
        else if (rightEdgeOfFormation > xMax)
        {
            isMovingRight = false;
        }
    }

    protected override void CalculateWidth()
    {
        width = EnemySpawnerWidth;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(EnemySpawnerWidth, EnemySpawnerHeight));
    }

    protected override void Update()
    {
        base.Update();

        if (IsAllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    private bool IsAllMembersDead()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
            enemy.transform.parent = freePosition;
        }

        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", SpawnDelay);
        }
    }

    private Transform NextFreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }
}