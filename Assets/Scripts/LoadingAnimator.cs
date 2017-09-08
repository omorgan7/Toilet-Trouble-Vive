using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimator : MonoBehaviour {
	Image image;
	public float asyncLevelProgress = 0f;
	public bool isDone = false;
	float prevLevelProgress = 0f;

	void Start(){
		image = gameObject.GetComponent<Image>();
	}

	public void FillAnimate(float t){
		t = Mathf.Clamp(t,0,1);
		image.fillAmount = (1-t);
	}

	void LateUpdate(){
		if(prevLevelProgress >= 1f){
			isDone = true;
			return;
		}
		if(prevLevelProgress < asyncLevelProgress){
			prevLevelProgress += Time.deltaTime;
			FillAnimate(prevLevelProgress);
		}
		
	}
}
