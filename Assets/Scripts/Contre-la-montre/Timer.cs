using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime;
	private bool finnished = false;
	private int nbrlap = 0;
	// Use this for initialization
	void Start () {
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (finnished)
			return;
		float t = Time.time - startTime;
		string minutes = ((int) t / 60).ToString();
		string second = (t % 60).ToString ("f2");
		timerText.text = "time : " + minutes + ":" + second + " | lap : " + (nbrlap / 3) + " /3" ;
		timerText.color = Color.blue;
	}
	public void Finnish(){
		finnished = true;
		timerText.color = Color.red;
	}
	public void Lap(){
		nbrlap += 1;
	
	}
}
