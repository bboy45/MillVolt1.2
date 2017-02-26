using UnityEngine;
using System.Collections;

public class IAMove : MonoBehaviour {
    public GameObject[] waypoints;
    public int num = 0;

    public int minDist;
    public float accelerationx;
    public bool rand = false;
    public bool go = true;
    // Use this for initialization
	void Start () {
        accelerationx = 0.04f;
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
        if (go)
        {
            if (dist > minDist)
            {
                Move();
                if (accelerationx < 140f)
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
    public void Move()
    {
        
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.position += gameObject.transform.forward * accelerationx * Time.deltaTime;
        transform.Rotate(0, 270, 0);

    }
}
