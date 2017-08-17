using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementController
{
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
}