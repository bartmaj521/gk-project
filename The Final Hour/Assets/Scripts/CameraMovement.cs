using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        Vector3 position = Player.position;
        position.y = transform.position.y;
        position.x -= 3;
        transform.position = position;
        transform.LookAt(Player);
    }
}
