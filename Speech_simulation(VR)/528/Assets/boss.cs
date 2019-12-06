using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {

	GameObject main ;
	Animator anim;
	int rand;

	private string[] parameter;

	string temp;
	// Use this for initialization
	void Start () {
		main = GameObject.Find ("ayde");
		anim = main.GetComponent<Animator> ();
		parameter = new string[]{"A1","A2","A3","A4"};

	}

	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.D)){
			

				rand = Random.Range (0, 2);

			if (temp != null) {
				anim.SetBool (temp, false);
			}
			if (temp == null) {

			}

			temp = parameter [rand];
			anim.SetBool(temp ,true);


		}

		
	}


}
