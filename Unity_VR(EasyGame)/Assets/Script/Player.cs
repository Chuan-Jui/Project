using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float hp = 500.0f;
	public int money = 100;
	public int bullet = 7;
	public int backupBullet = 70;
	public int score = 0;
	public GameManager gm;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		gm.Score.text += score + "";
		gm.Money.text += money + "";
	}
	
	// Update is called once per frame
	void Update () {
		


		if (bullet > 0) {
			gm.NoBullet.enabled = false;
		}

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (bullet > 0) {
				anim.SetBool ("shoot", true);
				bullet--;
				if(gm.enemy.tag == "Enemy")
				gm.enemy.GetComponent<Enemy> ().hp--;
				gm.bullet.text = bullet + "";
			}
			if (bullet <= 0 && backupBullet <= 0) {
				gm.NoBullet.enabled = true;
				bullet = 0;
				backupBullet = 0;
			}else if (bullet <= 0) {
				backupBullet -= 7;
				bullet += 7;
			}
			gm.bullet.text = bullet + "";
			gm.backupBullet.text = backupBullet + "";


		} else {
			anim.SetBool ("shoot", false);

		}

	}

}
