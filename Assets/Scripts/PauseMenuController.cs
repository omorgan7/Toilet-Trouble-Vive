using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
	public GameObject pauseMenu;

	void Update(){
		// if(GvrController.AppButtonUp){
		// 	if(pauseMenu != null){
		// 		Time.timeScale = 0f;
		// 		pauseMenu.SetActive(true);
		// 	}
		// }
	}

	public void ClosePauseMenu(){
		if(pauseMenu != null){
			pauseMenu.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}
