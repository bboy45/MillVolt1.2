using UnityEngine;
using System.Collections;

public class respawntimer : MonoBehaviour {
	float starttime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - starttime;
		if (t > 5) {
			this.gameObject.SetActive (true);

		}

	}
	public void OnTriggerEnter(Collider other){
		this.gameObject.SetActive (false);
		starttime = Time.time;	
	}
}
