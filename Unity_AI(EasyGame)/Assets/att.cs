using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class att : MonoBehaviour {
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

	void OnTriggerEnter(Collider hitMe)
	{
		if (hitMe.gameObject.tag == "eney") {
			playerhp.addHP ();
			Destroy (hitMe.gameObject);
		}
		else if (hitMe.gameObject.tag == "bad"){
			playerhp.lessHP ();

		}
	}

}
