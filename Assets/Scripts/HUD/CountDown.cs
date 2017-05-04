using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {
    float time = 3.5f;
    public Text countdown;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        countdown.text = Mathf.Round(time).ToString();
        countdown.alignment = TextAnchor.MiddleCenter;
        if (time < 0.5f)
        {
            countdown.text = "START !!!";
        }
        if (time < -2)
        {
            Destroy(gameObject);
        }
	}
}
