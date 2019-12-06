using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bearatt : MonoBehaviour {

	public GameObject otherGameObject;
	private playerHP playerhp;

	// Use this for initialization
	void Start () {
		playerhp = otherGameObject.GetComponent<playerHP>();
	}

	// Update is called once per frame
	void Update () {

	}

	/*void OnTriggerEnter(Collider c){
	
		if (c.tag == "tree") {
			Destroy (c.gameObject);
		}
	
	}
	*/

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "bear") {
			playerhp.bearatt ();
			Destroy (c.gameObject);
		}
	
	}

}
