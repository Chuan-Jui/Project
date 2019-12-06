using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame


		void OnTriggerEnter(Collider c){

			if (c.tag == "win") {
				Application.LoadLevel("menu");
			}

		
	
}
}
