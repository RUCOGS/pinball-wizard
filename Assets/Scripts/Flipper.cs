using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float startAngle;
    public float maxAngle;
    public float rotationTime;
    public KeyCode triggerKey;

    private Rigidbody2D rigidbody2D;

    private bool running = false;
    private float startTime = 0.0f;

	// Use this for initialization
	private void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    private void Update()
    {
        if (running)
        {
            var  delta = Time.time - startTime;
            if (delta > rotationTime)
            {
                running = false;
                rigidbody2D.MoveRotation(startAngle);
            }
            else
            {
                rigidbody2D.MoveRotation(startAngle + (maxAngle - startAngle) * Easing(delta / rotationTime));
            }
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