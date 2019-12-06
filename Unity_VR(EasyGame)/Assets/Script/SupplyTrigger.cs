using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SupplyTrigger : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler{

	public Text secText;
	string name = "";
	public Player player;
	public GameManager gm;
	// Use this for initialization
	void Start () {
		name = this.gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (MyTimer.GetInstance ().timeOut == true) {
			print ("Time out!");
			secText.text = "";
			if (player.money > 0) {
				if (name == "Ammo") {
					if (player.backupBullet < 70) {
						player.backupBullet += 35;
						player.money -= 70;
						gm.Money.text = "Money:"+player.money + "";


					}
					if (player.backupBullet > 70) {
						player.backupBullet = 70;
					}
					gm.backupBullet.text = player.backupBullet + "";
				} else if (name == "Aid") {
					
					if (player.hp < 500) {
						player.money -= 250;
						gm.Money.text = "Money:"+player.money + "";
						player.hp += 250;
						gm.slider.value = player.hp ;
					}
					if (player.hp > 500) {
						player.hp = 500;
					}
					gm.hp.text = player.hp + "";
				}
			} else {
				gm.NoMoney.enabled = true;
			}
		}
	}

	public void OnPointerEnter(PointerEventData e){
		if (name == "Ammo") {
			gm.AmmoPrice.enabled = true;
		} else if(name == "Aid"){
			gm.AidPrice.enabled = true;
		}
		MyTimer.GetInstance ().StartTimer(1.0f,secText);
		secText.enabled = true;
	}
	public void OnPointerExit(PointerEventData e){
		gm.AmmoPrice.enabled = false;
		gm.AidPrice.enabled = false;
		MyTimer.GetInstance ().stopTimer ();
		secText.enabled = false;
		gm.NoMoney.enabled = false;
	}
}
