using UnityEngine;
using System.Collections;

public class Foudre : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Notre Voiture").SendMessage("Foudre");
    }
}
