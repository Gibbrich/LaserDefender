using UnityEngine;

public abstract class MovementController : MonoBehaviour
{
    protected static float xMin;
    protected static float xMax;
    
    public float MovementSpeed = 5f;

    protected float width;

    protected virtual void Start()
    {
        if (xMin == 0 || xMax == 0)
        {
            Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
            xMin = leftMost.x;
            xMax = rightMost.x;
        }
        
        CalculateWidth();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected abstract void CalculateWidth();
}