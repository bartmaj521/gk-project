using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO make bullet deal damage
public class Bullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name != "Player")
            Destroy(this.gameObject);
    }
}
