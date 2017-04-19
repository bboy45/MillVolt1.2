using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartToMenu : MonoBehaviour {

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
        }
    }

}
