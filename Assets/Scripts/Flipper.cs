using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public float pushForce;

    private Rigidbody2D rigidbody2D;

    private bool running = false;
    private float startTime = 0.0f;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            float delta = Time.time - startTime;
            if (delta > 0.6)
            {
                running = false;
                rigidbody2D.MoveRotation(0);
            }
            else
            {
                rigidbody2D.MoveRotation(90 * Easing(delta / 0.6f));
            }
        }
        else
        {
            if (Input.GetKeyDown("right"))
            {
                running = true;
                startTime = Time.time;
            }
        }
    }

    float Easing(float p)
    {
        if ((1-p) < 0.4)
        {
            return Mathf.Exp(1.733f * (1-p)) - 1;
        }
        else
        {
            return Mathf.Exp(-11.5129f * (1-p) + 4.60517f) - 0.001f;
        }
    }
}