using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    Rigidbody body;

    [SerializeField]
    float forwardInput;
    [SerializeField]
    float sideInput;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody>();

        forwardInput = 0f;
        sideInput = 0f;
	}

    // Update is called once per frame
    void Update() {
        forwardInput = Input.GetAxis("Forward");
        if (Mathf.Abs(forwardInput) > 0)
        {
            body.MovePosition(body.position + (Vector3.forward * -1 * forwardInput));
            //body.AddRelativeForce(Vector3.forward);
            //body.AddForce(Vector3.forward);
        }

        sideInput = Input.GetAxis("Sideways");
        if (Mathf.Abs(sideInput) > 0)
        {
            body.MovePosition(body.position + (Vector3.right * forwardInput));
        }
    }
}
