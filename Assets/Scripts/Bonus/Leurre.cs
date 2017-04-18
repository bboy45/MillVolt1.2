using UnityEngine;
using System.Collections;

public class Leurre : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Notre Voiture")
        {
            GameObject.Find("Notre Voiture").SendMessage("Leurre");
            Destroy(gameObject);
        }
    }
}
