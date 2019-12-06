using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour {
	public float totalHP = 100f;
	Animator anim;

	// Use this for initialization
	void Start () {
		totalHP = 100f;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "God") {
			totalHP -= 50 ;
			if (totalHP < 0) {
				anim.SetBool ("die", true);
				Destroy (gameObject, 1.2f);
			}
		
		
		}
				


}
}