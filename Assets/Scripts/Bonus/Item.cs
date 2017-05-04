using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    int[] list;
    System.Random rnd;
    int random;
    public Text itemdisplay;
	// Use this for initialization
	void Start () {
        list = new int[1];
        rnd = new System.Random();

	}
	
	// Update is called once per frame
	void Update () {
        itemdisplay.text = "None";
        if (list[0] > 0 && list[0] < 4)
        {
            if (list[0] == 1)
            {
                itemdisplay.text = "Leurre";
            }
            if (list[0] == 2)
            {
                itemdisplay.text = "Foudre";
            }
            if (list[0] == 3)
            {
                itemdisplay.text = "Generateur";
            }
            if (list[0] == 4)
            {
                itemdisplay.text = "";
            }
            if (list[0] == 5)
            {
                itemdisplay.text = "";
            }
            if (list[0] == 6)
            {
                itemdisplay.text = "";
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (list[0] == 1)
                {
                    GameObject.Find("Birdy").SendMessage("Leurre");
                }
                if (list[0] == 2)
                {
                    GameObject.Find("Birdy").SendMessage("Foudre");
                }
                if (list[0] == 3)
                {
                    GameObject.Find("Notre Voiture").SendMessage("Generateur");
                }
                if (list[0] == 4)
                {

                }
                if (list[0] == 5)
                {

                }
                if (list[0] == 6)
                {

                }
                list[0] = 0;
            }
        }
	}
    public void ItemS()
    {
        list[0] = rnd.Next(1,4);
    }
}
