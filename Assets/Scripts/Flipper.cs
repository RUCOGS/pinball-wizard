using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Flipper : MonoBehaviour
{
    public KeyCode triggerKey;
    public float degreeChange;
    public float rotationTime;
    
    private Rigidbody2D rigidbody2D;
    
    private float startAngle;
    private float coefficient;
    
    private bool running = false;
    private float startTime = 0.0f;

	private void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	    
	    // startAngle and coefficient are calculated on Start from the public values, and
	    // the beginning angle of the object
	    startAngle = transform.eulerAngles.z;
	    coefficient = degreeChange / rotationTime;
	}

    private void Update()
    {
        if (running)
        {
            float angle;
            var  delta = Time.time - startTime;
            if (delta > rotationTime)
            {
                running = false;
                angle = startAngle;
            }
            else
            {
                angle = startAngle + coefficient * Easing(delta / rotationTime);
            }
            rigidbody2D.MoveRotation(angle);
        }
        else if (Input.GetKeyDown(triggerKey))
        {
            running = true;
            startTime = Time.time;
        }
    }

    /**
     *  Takes a number  0-1, and gives a number 0-1
     */
    private static float Easing(float p)
    {
        if (p < 0.5)
        {
            return 2 * p;
        }
        else
        {
            return 2 - 2 * p;
        }
    }
}