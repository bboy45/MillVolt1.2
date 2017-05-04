using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lap : MonoBehaviour {
    public Text lap;
    public Text finish;
    int nbrtour;

	// Use this for initialization
	void Start () {
        nbrtour = -1;
        lap.text = "0 / 3";
    }
	
	// Update is called once per frame
	void Update () {
        lap.alignment = TextAnchor.MiddleCenter;
        if (nbrtour > -1)
        {
            lap.text = nbrtour.ToString() + " / 3";
        }
        if (nbrtour >= 3)
        {
            lap.text = "3 / 3";
            finish.alignment = TextAnchor.MiddleCenter;
            finish.text = "Finish !";
        }
	}
    public void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Notre Voiture").SendMessage("Lap");
        if (nbrtour >= 3)
        {
            GameObject.Find("Birdy").SendMessage("Finish");
            GameObject.Find("Timer2").SendMessage("Finish");
        }
    }
    public void FinishPlayer()
    {
        nbrtour += 1;
    }   
}
