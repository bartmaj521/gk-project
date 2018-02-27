using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            Vector3 lol = transform.position;
            lol.x += Speed * Time.deltaTime;
            transform.position = lol;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 lol = transform.position;
            lol.x -= Speed * Time.deltaTime;
            transform.position = lol;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 lol = transform.position;
            lol.z += Speed * Time.deltaTime;
            transform.position = lol;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 lol = transform.position;
            lol.z -= Speed * Time.deltaTime;
            transform.position = lol;
        }
    }
}
