using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    // The target marker.
    private Transform target;

    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;

    // Angular speed in radians per sec.
    public float speed = 1.0f;

    void Start()
    {
        target = target1;
    }

    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void SetToPosition(int pos)
    {
        if (pos == 1)
        {
            target = target1;
        }
        if (pos == 2)
        {
            target = target2;
        }
        if (pos == 3)
        {
            target = target3;
        }
        if (pos == 4)
        {
            target = target4;
        }
    }

}
