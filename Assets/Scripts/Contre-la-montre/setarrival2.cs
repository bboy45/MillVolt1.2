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
            GameObject.Find("carfast1").SendMessage("Begin");
            GameObject.Find("carfast1").SendMessage("Lap");
        }
        else
        {
            if (nbrtour == 3)
            {
                GameObject.Find("carfast1").SendMessage("Finish");
            }
            else
                GameObject.Find("carfast1").SendMessage("Lap");
        }
        nbrtour += 1;

    }
}
