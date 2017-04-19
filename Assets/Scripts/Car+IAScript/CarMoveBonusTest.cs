using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarMoveBonusTest : MonoBehaviour
{
    float accelerationx;
    float decelerationx;
    bool inter;
    bool startfoudre = false;
    bool startgenerateur = false;
    float generateurtime;
    float foudretime;
    Rigidbody rb;
    float kph;
    string speednumber;
    public Text speed;
	bool startleurre = false;
	float leurretime;
    // Use this for initialization
    public void Start()
    {
        accelerationx = 0.04f;
        decelerationx = -0.04f;
        rb = GetComponent<Rigidbody>();
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
    void Update()
    {
		if (startgenerateur) {
			if (Time.time - generateurtime - 5 < 0) {
				startgenerateur = false;
				generateurtime = 0;
			}
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
		if (startleurre) {
			if (Time.time - foudretime <= 4) {
				transform.Translate (0, 3, 0);
			
			} else {
				startleurre = false;
				foudretime = 0;
			}
		}
		if (!startleurre) {
			if (Input.GetKey (KeyCode.UpArrow) && inter && transform.rotation.x > -25 && transform.rotation.x < 25) {

				if (startgenerateur) {
					accelerationx += 5f;
				} else {
					if (accelerationx < 2.1f) {
						accelerationx += 0.02f;
					}
				}
			}
			if (Input.GetKey (KeyCode.DownArrow) && inter && transform.rotation.x > -25 && transform.rotation.x < 25) {
				if (decelerationx > -2f) {
					decelerationx -= 0.02f;
				}
			}
			if (Input.GetKey (KeyCode.LeftArrow) && inter) {

				transform.Rotate (0, -4f, 0);
				/*if (accelerationx + decelerationx > 0.2f)
            {

            }
            else */
				if (accelerationx + decelerationx <= 0.2f) {
					transform.Translate (0.4f, 0, 0);
				} else {
					transform.Translate (decelerationx, 0, 0);
				}
			}
			if (Input.GetKey (KeyCode.RightArrow) && inter) {
				transform.Rotate (0, 4f, 0); /*
            if (accelerationx + decelerationx > 0.2f)
            {

            }
            else */
				if (accelerationx + decelerationx <= 0.2f) {
					transform.Translate (0.4f, 0, 0);
				} else {
					transform.Translate (decelerationx, 0, 0);
				}
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
        kph = rb.velocity.magnitude * 360f;
        speednumber = kph.ToString();
        speed.text = speednumber + " KM/H";
    }
   
    public void Foudre() {
        startfoudre = true;
        accelerationx = 0;
        decelerationx = 0;
        foudretime = Time.time;

    }
    public void Leurre() {
        //transform.position = new Vector3(transform.position.x, 40, transform.position.z);
        //faire sauter la voiture pas TP.
        accelerationx = 0;
		decelerationx = 0;
		leurretime = Time.time;
		startleurre = true;
        //decelerationx = 0;
        
    }
	public void Generateur()
	{
		startgenerateur = true;
		generateurtime = Time.time;
		accelerationx += 5f;
	}
}
