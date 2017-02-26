using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {
    float accelerationx;
    float decelerationx;
    bool inter;

    // Use this for initialization
    public void Start () {
	    accelerationx = 0.04f;
        decelerationx = -0.04f;
        transform.position = new Vector3(12, 1, 250);
    }
	
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            inter = true;
        }
        if (col.gameObject.name == "BXC departure" || col.gameObject.name == "BXC arrival" || col.gameObject.name == "BXC LS" || col.gameObject.name == "BXC RS")
        {
            inter = true;
            accelerationx = 0.02f;
            decelerationx = -0.02f;
        }
    }

    public void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            inter = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.UpArrow) && inter && transform.rotation.x > -25 && transform.rotation.x < 25)
        {
            if (accelerationx < 2.7f)
            {
                accelerationx += 0.02f;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && inter && transform.rotation.x > -25 && transform.rotation.x < 25)
        {
            if (decelerationx > -2f)
            {
                decelerationx -= 0.02f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) && inter) {

            transform.Rotate(0, -4f, 0);
            if (accelerationx + decelerationx > 0.2f)
            {
                
            }
            else if (accelerationx + decelerationx <= 0.2f)
            {
                transform.Translate(0.4f, 0, 0);
            }
            else { transform.Translate(decelerationx, 0, 0); }
        }
        if (Input.GetKey(KeyCode.RightArrow) && inter)
        {
            transform.Rotate(0, 4f, 0);
            if (accelerationx + decelerationx > 0.2f)
            {
                
            }
            else if (accelerationx + decelerationx <= 0.2f)
            {
                transform.Translate(0.4f, 0, 0);
            }
            else { transform.Translate(decelerationx, 0, 0); }
        }
        if (accelerationx > 0)
        {
            accelerationx -= 0.006f;
        }
        if (decelerationx < 0)
        {
            decelerationx += 0.006f;
        }
        transform.Translate(accelerationx + decelerationx, 0, 0);
        if (transform.rotation.x > 35)
        {
            transform.Rotate(-7, 0, 0);
        }
        if (transform.rotation.x < -35)
        {
            transform.Rotate(7, 0, 0);
        }
        if (transform.rotation.z > 35)
        {
            transform.Rotate(0, 0, -5);
        }
        if (transform.rotation.z < -35)
        {
            transform.Rotate(0, 0, 5);
        }
        Physics.gravity = new Vector3(0,-160,0);
        
    }
}
