using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer2 : MonoBehaviour {
    float countdown;
    float timer;
    float minute;
    float seconde;
    string niceTime;
    bool start;
    public Text time;
    // Use this for initialization
    void Start()
    {
        countdown = 3.5f;
        timer = 0;
        minute = 0;
        seconde = 0;
        time.alignment = TextAnchor.MiddleCenter;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0.5f && start)
        {
            timer += Time.deltaTime;
            minute = Mathf.FloorToInt(timer / 60F);
            seconde = Mathf.FloorToInt(timer - minute * 60);
            niceTime = string.Format("{0:0}:{1:00}", minute, seconde);
            time.alignment = TextAnchor.MiddleCenter;
            time.text = niceTime;
        }
        if (!start)
        {
            time.text = niceTime;
        }
    }
    public void Finish()
    {
        start = false;
    }
}
