using System.Collections;
using System.Collections.Generic;
//using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Flipper : MonoBehaviour
{
    public KeyCode triggerKey;
    public float degreeChange;
    public float forwardAcceleration;
    public float backwardAcceleration;
    
    private Rigidbody2D rigidbody2D;
    
    private float startAngle;
    private float endAngle;
    private float currentAngle;
    private float velocity = 0.0f;

	private void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	    
	    
	    startAngle = transform.eulerAngles.z;
	    endAngle = startAngle + degreeChange;
	    currentAngle = startAngle;
	}

    private void Update()
    {
        float accel;
        if (Input.GetKey(triggerKey))
        {
            accel = forwardAcceleration;
        }
        else
        {
            accel = backwardAcceleration;
        }

        velocity += accel;
        currentAngle += velocity;
        
        // Depending on startAngle and endAngle some extra logic is necessary if we cross over 360 degrees
        if (currentAngle < startAngle)
        {
            currentAngle = startAngle;
            velocity = 0;
        } else if (currentAngle > endAngle)
        {
            currentAngle = endAngle;
            velocity = 0;
        }

        rigidbody2D.MoveRotation(currentAngle);
    }
}