using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    private bool finnished = false;
    private int nbrlap = 0;
    private bool begun = false;
    // Use this for initialization
    void Start() {
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (begun) {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string second = (t % 60).ToString("f2");
            if (finnished) {
                return; }
        timerText.text = "time : " + minutes + ":" + second + " | lap : " + (nbrlap) + " /3";
        timerText.color = Color.blue;
    } else 
        timerText.text = "time : 0:0.00 | lap : 0 /3";
}
	public void Finish(){
		finnished = true;
        timerText.text += "   finish!";
        timerText.color = Color.red;
	}
    public void Begin() {
        begun = true;

    }
	public void Lap(){
		nbrlap += 1;
	
	}
}
