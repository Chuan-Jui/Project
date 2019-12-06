using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI3 : MonoBehaviour {

	public Transform player;
	public Transform head;

	string state= "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.2f;
	public float speed = 1.5f;
	float accuracyWP = 5.0f;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update ()
	{

	

		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		float angle = Vector3.Angle (direction, head.up);

		if (state == "patrol" && waypoints.Length > 0) {
			anim.SetBool ("idle", false);
			anim.SetBool ("run", true);
			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) {
				currentWP = Random.Range (0, waypoints.Length);
			}
			direction = waypoints [currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation,
				Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}

		if (Vector3.Distance (player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing")) 
		{
			state = "pursuing";
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
				Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);

			if (direction.magnitude > 5) {
				this.transform.Translate (0, 0, Time.deltaTime * speed);
				anim.SetBool ("run", true);
				anim.SetBool ("att", false);
			} else {
				anim.SetBool ("att", true);
				anim.SetBool ("run", false);
			}
		} 
		else 
		{
			anim.SetBool ("run", true);
			anim.SetBool ("att", false);
			state = "patrol";
		}
	}
				
}				
			
