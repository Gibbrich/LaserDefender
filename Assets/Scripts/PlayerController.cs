using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 5f;

    private float xMin;
    private float xMax;
    private float playerWidth;

    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x;
        xMax = rightMost.x;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerWidth = player.GetComponent<SpriteRenderer>().bounds.max.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaHorizontal = new Vector3(Input.GetAxisRaw("Horizontal") * MovementSpeed * Time.deltaTime, 0);
        Vector3 newPosition = transform.position + deltaHorizontal;
        newPosition.x = Mathf.Clamp(newPosition.x, xMin + playerWidth, xMax - playerWidth);

        transform.position = newPosition;
    }
}