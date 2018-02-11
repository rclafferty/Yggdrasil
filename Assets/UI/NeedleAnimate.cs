using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleAnimate : MonoBehaviour {

    public GameObject player;
   //public RectTransform needle;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
        //needle = GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.rotation = Quaternion.Euler(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.y);
        this.transform.rotation = Quaternion.Euler(0, 0, player.transform.eulerAngles.y);

        //this.rotation = Quaternion.Euler(player.transform., 0, 1);

    }
}
