using UnityEngine;
using System.Collections;

public class setarrival2 : MonoBehaviour {

	int nbrtour = 0;
	// Use this for initialization
	/*void Start () {
	
	}*/

	// Update is called once per frame
	/*void Update () {

	}*/
	public void OnTriggerEnter(Collider other){
		// nbrtour = 9 pour 3 tours
		// nbrtour = 6 pour 2 tours
		// nrbtour = 3 pour 1 tour
		if (nbrtour < 3) {
			nbrtour += 1;
			GameObject.Find ("Notre Voiture").SendMessage ("Lap");
		}
		else
			GameObject.Find ("Notre Voiture").SendMessage ("Finish");


	}
}
