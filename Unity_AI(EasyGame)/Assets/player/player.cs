using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	Animator anim;
	public playerHP HP;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("run", true);
			transform.position += transform.forward * 10.0f * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.W)) {
			anim.SetBool ("run", false);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up, 30.0f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.up, -30.0f * Time.deltaTime);

		}if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("run", true);
			transform.position += transform.forward * -1*10.0f * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			anim.SetBool ("run", false);
		}
		if (Input.GetButton ("Fire1")) {
			anim.SetBool ("att", true);
		}
		if (Input.GetButtonUp ("Fire1")) {
			anim.SetBool ("att", false);
		}
		if (HP.nowPos < -180f) {
			anim.SetBool ("die", true);
		

		}


	}
}
