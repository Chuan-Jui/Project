﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyAI2 : MonoBehaviour {
	public Transform player;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(player.position,this.transform.position)<20)
		{
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
				Quaternion.LookRotation (direction), 0.1f);

			anim.SetBool ("idle", false);
			if(direction.magnitude >5)
				{
					this.transform.Translate(0,0,0.05f);
					anim.SetBool("run",true);
					anim.SetBool("att",false);
				}
				else
				{
					anim.SetBool("att",true);
					anim.SetBool("ren",false);
				}
			}
			else
			{
				anim.SetBool("idle",true);
				anim.SetBool("run",false);
				anim.SetBool("att",false);
			}

		
	}
}
