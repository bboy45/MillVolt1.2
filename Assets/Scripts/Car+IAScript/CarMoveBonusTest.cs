using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.Networking;

public class CarMoveBonusTest : MonoBehaviour
{
    float accelerationx;
    float decelerationx;
    public Transform leurreanim;
    public Transform generanim;
    public Transform foudreanim;
    float time = 3.5f;
    bool inter;
    bool startfoudre = false;
    bool startgenerateur = false;
    bool countdown;
    float generateurtime;
    float foudretime;
    // Use this for initialization
    public void Start()
    {
        accelerationx = 0.04f;
        decelerationx = -0.04f;
        transform.position = new Vector3(804, 49, 421);
        countdown = false;      
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.position = new Vector3 (804, 48, 380);
            
            accelerationx = 0;
            decelerationx = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
        }
        time -= Time.deltaTime;
        if (time < 0.5f)
        {
            countdown = true;
        }
        if (Time.time - generateurtime - 2 < 0)
            {

                startgenerateur = false;
                generateurtime = 0;
            }
        if (startfoudre) {
            if (Time.time - foudretime <= 2)
            {
                accelerationx = 0;
                decelerationx = 0;

            }
            else {
                startfoudre = false;
                foudretime = 0;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)  && transform.rotation.x > -25 && transform.rotation.x < 25 && countdown)
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

            }
        }
        if (Input.GetKey(KeyCode.DownArrow)  && transform.rotation.x > -25 && transform.rotation.x < 25 && countdown)
        {
            if (decelerationx > -2f)
            {
                decelerationx -= 0.02f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)  && countdown)
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
        if (Input.GetKey(KeyCode.RightArrow)  && countdown)
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
        if (Input.GetKey(KeyCode.J))
        {
            GameObject.Find("Birdy").SendMessage("Bullshit");
        }

        //if (Input.GetKey(KeyCode.R))
        //{
        //    transform. ;
        //}

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
        Physics.gravity = new Vector3(0, -160, 0);

        
    }
    public void Generateur()
    {
        startgenerateur = true;
        generateurtime = Time.time;
        accelerationx += 3f;
        generanim.GetComponent<ParticleSystem>().Play();
    }
    public void Foudre() {
        startfoudre = true;
        accelerationx = 0;
        decelerationx = 0;
        foudretime = Time.time;
        foudreanim.GetComponent<ParticleSystem>().Play();
    }
    public void Leurre() {
        transform.position = new Vector3(transform.position.x, 40, transform.position.z);
        //faire sauter la voiture pas TP.
        accelerationx = 0;
        decelerationx = 0;
        leurreanim.GetComponent<ParticleSystem>().Play();
    }
    public void Lap()
    {
        GameObject.Find("lap").SendMessage("FinishPlayer");
    }
}
