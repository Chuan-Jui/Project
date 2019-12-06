using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour {
	public float totalHP = 100f;
	public int changeHP;
	public float nowPos;
	// Use this for initialization
	void Start () {
		totalHP = 100f;
		changeHP = 0;
	}
	
	// Update is called once per frame
	void Update () {
		nowPos = -200 + 200 * ((totalHP + changeHP) / totalHP);
		transform.localPosition = new Vector3 (nowPos, 0f, 0f);
	}

	public void lessHP()
	{
		if (nowPos > -200) {
			changeHP -= 10;
		}
	}

	public void addHP()
	{
		if (nowPos <= 0) {
			changeHP += 10;
		}
	}
	public void bearatt()
	{
		if (nowPos > -200) {
			changeHP -= 50;
		}
	}


}
