using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerFunctions : MonoBehaviour {

	SceneState sceneState;

	enum Scenes {MainMenu,Loading,House,Japan,Space};
	void Start(){
		var temp = GameObject.FindGameObjectsWithTag("LoadingState");
		if(temp.Length < 1){
			return;
		}
		sceneState = temp[0].GetComponent<SceneState>();
	}
	public void LoadHouse(){
		sceneState.SceneIndex = (int) Scenes.House;
		LoadLoadingScreen();
	}
	public void LoadJapan(){
		sceneState.SceneIndex = (int) Scenes.Japan;
		LoadLoadingScreen();
	}
	public void LoadSpace(){
		sceneState.SceneIndex = (int) Scenes.Space;
		LoadLoadingScreen();
	}

	void LoadLoadingScreen(){
		SceneManager.LoadScene((int) Scenes.Loading);
	}

	public void RestartLevel(){
		Time.timeScale = 1f;
		LoadLoadingScreen();
	}

	public void LoadMenu(){
		Time.timeScale = 1f;
		sceneState.SceneIndex = (int) Scenes.MainMenu;
		LoadLoadingScreen();
	}

}
