using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerFunctions : MonoBehaviour {

	public SceneState sceneState;

	enum Scenes {MainMenu,Loading,House,Japan,Space};

	public void LoadHouse(){
		sceneState.SceneIndex = (int) Scenes.House;
		LoadLoadingScreen();
	}
	public void LoadJapan(){
		sceneState.SceneIndex = (int) Scenes.Japan;
		LoadLoadingScreen();
	}
	public void LoadSpace(){
		//sceneState.SceneIndex = (int) Scenes.Space;
		//LoadLoadingScreen();
	}

	void LoadLoadingScreen(){
		SceneManager.LoadScene((int) Scenes.Loading);
	}
}
