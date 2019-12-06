using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {
	public GameObject player;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position,transform.position) <=20f)
		{
			anim.SetBool ("run", true);
			transform.position += transform.forward * 5.0f * Time.deltaTime;

			transform.LookAt(player.transform);
	    }
	

			}
}
