using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassBehavior : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(this.transform.rotation.eulerAngles.y);

        this.transform.rotation = Quaternion.Euler(new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.y));
        
	}
}
