using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * 150), Space.Self);
        }
        else if (Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * -150), Space.Self);
        }
    }
}