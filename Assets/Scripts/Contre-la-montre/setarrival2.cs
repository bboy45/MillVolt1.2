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
        if (nbrtour == 0)
        {
            GameObject.Find("Notre Voiture").SendMessage("Begin");
            GameObject.Find("Notre Voiture").SendMessage("Lap");
        }
        else
        {
            if (nbrtour == 3)
            {
                GameObject.Find("Notre Voiture").SendMessage("Finish");
            }
            else
                GameObject.Find("Notre Voiture").SendMessage("Lap");
        }
        nbrtour += 1;

    }
}
