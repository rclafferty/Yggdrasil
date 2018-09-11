using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunManagerBehavior : MonoBehaviour {

    GameObject sun;

	// Use this for initialization
	void Start () {
        sun = GameObject.Find("Sun");
	}
	
	// Update is called once per frame
	void Update () {
        sun.transform.Rotate(Vector3.right, 0.050f);
	}
}
