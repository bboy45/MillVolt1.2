﻿using UnityEngine;
using System.Collections;

public class Generateur : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Notre Voiture").SendMessage("Generateur");
    }
}
