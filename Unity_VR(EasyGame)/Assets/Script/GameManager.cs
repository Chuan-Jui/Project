using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text Score;
	public Text bullet;
	public Text backupBullet;
	public Text hp;
	public Text Money;
	public Text NoBullet;
	public Text NoMoney;
	public Text AmmoPrice;
	public Text AidPrice;
	public Slider slider;
	public GameObject enemy;
	public bool isAim = false;
	public Transform[] summon;
	// Use this for initialization
	void Start () {
		NoBullet.enabled = false;
		AmmoPrice.enabled = false;
		AidPrice.enabled = false;
		NoMoney.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
