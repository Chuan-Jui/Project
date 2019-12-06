using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler{

	public int hp = 5;

	Animator anim;
    GameManager gm;
	Player player;
	Collider box;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public float attack = 50;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
		player = GameObject.Find ("Player").GetComponent<Player> ();
		box = GetComponentInChildren<BoxCollider> ();
		fireRate = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp == 0) {
			this.GetComponent<CapsuleCollider> ().enabled = false;
			anim.SetBool ("dying", true);
		
			StartCoroutine (WaitDying ());
		}
	}
	void OnTriggerStay(Collider c){
		if (c.name == "AttackTrigger" && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			anim.SetBool ("attack", true);
			StartCoroutine (WaitAtt ());
		} else if (c.name == "AttackTrigger" && Time.time <= nextFire) {
			anim.SetBool ("attack", false);
		}

	}

	public void OnPointerEnter(PointerEventData e){
		gm.enemy = this.gameObject;
		gm.isAim = true;
	}
	public void OnPointerExit(PointerEventData e){
		gm.enemy = GameObject.Find ("TempObject");
		gm.isAim = false;
	}
	IEnumerator WaitDying(){
		yield return new WaitForSeconds (2.0f);
		player.score += 100;
		player.money += 100;
		gm.Score.text = "Score:" + player.score;
		gm.Money.text = "Money:" + player.money;
		Destroy (this.gameObject);
	}
	IEnumerator WaitAtt(){
		yield return new WaitForSeconds (0.7f);
		player.hp -= attack;
		gm.slider.value = player.hp;
		gm.hp.text = player.hp + "";
	}

}
