using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	SceneState scenestate;
	public LoadingAnimator animator;

	void Start(){
		var temp = GameObject.Find("SceneStatePreserver");
		if(temp == null){
			return;
		}
		scenestate = temp.GetComponent<SceneState>();
		StartCoroutine(LoadNextLevel());
	}

	IEnumerator LoadNextLevel(){
		AsyncOperation ao = SceneManager.LoadSceneAsync(scenestate.SceneIndex);
		ao.allowSceneActivation = false;
		while(ao.progress <= 0.9 && !animator.isDone){
			animator.asyncLevelProgress = ao.progress + 0.1f;
			yield return null;
		}

		ao.allowSceneActivation = true;
		yield return true;
	}
	
}
