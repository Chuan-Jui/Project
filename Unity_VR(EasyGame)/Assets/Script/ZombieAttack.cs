using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

	Player player;
	public int attack = 50;
	GameManager gm;
	Animator anim;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<Player> ();
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		anim = GetComponentInParent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Player" ) {
			player.hp -= attack;
			gm.slider.value = player.hp;
			gm.hp.text = player.hp + ""; 
		} 
	}

}
