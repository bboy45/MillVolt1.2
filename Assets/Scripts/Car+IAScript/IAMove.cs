using UnityEngine;
using System.Collections;

public class IAMove : MonoBehaviour
{
    public Transform foudreanim;
    public Transform leurreanim;
    public GameObject[] waypoints;
    public int num = 0;
    public int minDist;
    public float accelerationx;
    public bool rand = false;
    public bool go = true;
    bool foudre;
    float time = 3.5f;
    float foudretime = 3f;
    // Use this for initialization
    void Start()
    {
        accelerationx = 0.04f;
        foudre = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
        time -= Time.deltaTime;
        if (time < 0.5f)
        {
            if (go)
            {
                if (dist > minDist)
                {
                    Move();
                    if (accelerationx < 120f)
                        accelerationx = accelerationx + 1f;
                }
                else
                {
                    if (!rand)
                    {
                        if (num + 1 == waypoints.Length)
                        {
                            num = 0;
                        }
                        else
                        {
                            num++;
                        }
                    }
                    else
                    {
                        num = Random.Range(0, waypoints.Length);
                    }
                }
            }
        }
        if (foudre)
        {
            foudretime -= Time.deltaTime;
            accelerationx = 0;
            if (foudretime < 0)
            {
                foudre = false;
                foudretime = 3f;
            }
        }
    }
    public void Move()
    {
        
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * accelerationx * Time.deltaTime;
        transform.Rotate(0, -90, 0);
    }
    public void Foudre()
    {
        foudreanim.GetComponent<ParticleSystem>().Play();
        foudre = true;
    }
    public void Leurre()
    {
        leurreanim.GetComponent<ParticleSystem>().Play();
        transform.position = new Vector3(transform.position.x, 120, transform.position.z);
        //faire sauter la voiture pas TP.
        accelerationx = 0;

    }
    public void Bullshit()
    {
        accelerationx = 0;
    }
    public void Finish()
    {
        go = false;
    }
}
