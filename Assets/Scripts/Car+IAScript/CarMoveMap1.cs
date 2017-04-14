using UnityEngine;
using System.Collections;

public class CarMoveMap1 : MonoBehaviour {

    float accelerationx;
    float decelerationx;
    bool colbg;

    // Use this for initialization
    public void Start()
    {
        accelerationx = 0.04f;
        decelerationx = -0.04f;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "GameObject 1" || collision.gameObject.name == "GameObject 2" || collision.gameObject.name == "GameObject 3" || collision.gameObject.name == "GameObject 4" || collision.gameObject.name == "GameObject 5" || collision.gameObject.name == "GameObject 6" || collision.gameObject.name == "GameObject 7" || collision.gameObject.name == "GameObject 8")
        {
            colbg = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "GameObject 1" || collision.gameObject.name == "GameObject 2" || collision.gameObject.name == "GameObject 3" || collision.gameObject.name == "GameObject 4" || collision.gameObject.name == "GameObject 5" || collision.gameObject.name == "GameObject 6" || collision.gameObject.name == "GameObject 7" || collision.gameObject.name == "GameObject 8")
        {
            colbg = false;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.rotation.x > -25 && transform.rotation.x < 25)
        {
            if (accelerationx < 1.8f)
            {
                accelerationx += 0.02f;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.rotation.x > -25 && transform.rotation.x < 25)
        {
            if (decelerationx > -2f)
            {
                decelerationx -= 0.02f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

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
        if (Input.GetKey(KeyCode.RightArrow))
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
        if (colbg)
        {
            accelerationx = 0;
            decelerationx = 0;
        }
        Physics.gravity = new Vector3(0, -160, 0);

    }
}
