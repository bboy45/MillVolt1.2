using UnityEngine;
using System.Collections;

public class RespawnTime68 : MonoBehaviour
{

    float time;
    bool spawn;
    // Use this for initialization
    void Start()
    {
        time = 2f;
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                transform.position = new Vector3(transform.position.x, 68f, transform.position.z);
                time = 2f;
            }
        }


    }
    public void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, -100, transform.position.z);
        time = 2f;
        spawn = false;
    }
}

