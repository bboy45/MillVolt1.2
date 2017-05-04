using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public Transform mainMenu, optionsMenu,PlayMenu;

	public void LoadScene(string name){
		Application.LoadLevel(name);
	}
	public void QuitGame(){
		Application.Quit();
	}
	public void OptionsMenu(bool clicked){
		if (clicked == true){
			optionsMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(false);
		} else {
			optionsMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(true);
		}
	}
    public void playMenu(bool clicked)
    {
        if (clicked == true)
        {
            PlayMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            PlayMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }


}
