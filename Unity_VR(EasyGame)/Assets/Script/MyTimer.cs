using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour {

	static MyTimer mInstance;

	public float duration = 2.0f;
	public float curTime = 0;
	public bool loop = false;
	public bool running = false;
	public bool timeOut = false;
	private Text secText;

	public static MyTimer GetInstance(){
		if (mInstance == null) {
			GameObject go = new GameObject ();
			mInstance = go.AddComponent<MyTimer> ();
		}
		return mInstance;
	}

	void Update(){
		if (timeOut == true) {
			timeOut = false;
		}
		if (running == true) {
			curTime += Time.deltaTime;
			if (curTime >= duration) {
				timeOut = true;
				curTime -= duration;
				if (loop == false) {
					running = false;
					curTime = 0;
				}
			}
			secText.text = (int)(curTime * 10 )+ "";
		}
	}
	public void StartTimer(float _duration,Text sec){
		secText = sec;
		duration = _duration;
		curTime = 0;
		running = true;
		timeOut = false;
	}

	public void stopTimer(){
		running = false;
		curTime = 0;
	}


}
