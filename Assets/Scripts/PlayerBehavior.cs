using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //if (collision.collider.name == "COOL_Terrain" || collision.collider.name == "Terrain")
        if (collision.collider.name == "cave ball smooth floor")
            return;

        Debug.Log("Collided with " + collision.collider.name);
        if (collision.collider.name == "Door" && Input.GetAxis("Fire") > 0)
        {
            Debug.Log("Destroying " + collision.collider.name);
            BurnDoor(collision);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void BurnDoor(Collision collision)
    {
        Debug.Log("Burning " + collision.collider.name);
        collision.collider.GetComponent<DoorBehavior>().Burn();
    }
}
