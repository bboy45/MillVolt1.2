using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.Networking;

public class CarMoveBonusTest : MonoBehaviour
{
    float accelerationx;
    float decelerationx;
    bool inter;
    bool startfoudre = false;
    bool startgenerateur = false;
    float generateurtime;
    float foudretime;
    int kph1;
    int kph2;
    string speednumber;
    public Text speed;
    // Use this for initialization
    public void Start()
    {
        accelerationx = 0.04f;
        decelerationx = -0.04f;
        //transform.position = new Vector3(12, 1, 250);
       
       
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
    void Update()
    {
        
            if (Time.time - generateurtime - 5 < 0)
            {

                startgenerateur = false;
                generateurtime = 0;
            }
        if (startfoudre) {
            if (Time.time - foudretime <= 3)
            {
                accelerationx = 0;
                decelerationx = 0;

            }
            else {
                startfoudre = false;
                foudretime = 0;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)  && transform.rotation.x > -25 && transform.rotation.x < 25)
        {

            if (startgenerateur)
            {
                accelerationx += 5f;
            }
            else
            {
                if (accelerationx < 2.1f)
                {
                    accelerationx += 0.02f;
                }
                if (kph1 < 250)
                {
                    kph1 += 2;
                }
            }
        }
        if (Input.GetKey(KeyCode.DownArrow)  && transform.rotation.x > -25 && transform.rotation.x < 25)
        {
            if (decelerationx > -2f)
            {
                decelerationx -= 0.02f;
            }
            if (kph2 > -250)
            {
                kph2 -= 2;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Rotate(0, -4f, 0);
            /*if (accelerationx + decelerationx > 0.2f)
            {

            }
            else */
            if (accelerationx + decelerationx <= 0.2f)
            {
                transform.Translate(0.4f, 0, 0);
            }
            else
            {
                transform.Translate(decelerationx, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 4f, 0); /*
            if (accelerationx + decelerationx > 0.2f)
            {

            }
            else */
            if (accelerationx + decelerationx <= 0.2f)
            {
                transform.Translate(0.4f, 0, 0);
            }
            else {
                transform.Translate(decelerationx, 0, 0);
            }
        }
        if (accelerationx > 0)
        {
            accelerationx -= 0.006f;           
        }
        if (decelerationx < 0)
        {
            decelerationx += 0.006f;
        }
        if (kph1 > 0)
        {
            kph1 -= 1;
        }
        else
        {
            kph1 = 0;
        }
        if (kph2 < 0)
        {
            kph2 += 1;
        }
        else
        {
            kph2 = 0;
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
        Physics.gravity = new Vector3(0, -160, 0);
        if (kph1 > 0)
        {
            speednumber = kph1.ToString();
            speed.text = speednumber + " KM/H";
        }
        
    }
    /*public void Generateur()
    {
        startgenerateur = true;
        generateurtime = Time.time;
        accelerationx += 5f;
    }
    public void Foudre() {
        startfoudre = true;
        accelerationx = 0;
        decelerationx = 0;
        foudretime = Time.time;

    }
    public void Leurre() {
        transform.position = new Vector3(transform.position.x, 40, transform.position.z);
        //faire sauter la voiture pas TP.
        accelerationx = 0;
        decelerationx = 0;
        
    }*/
}
