using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpashControllerBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("GameManager").GetComponent<GameManaging>().Fade("title");
	}
}
