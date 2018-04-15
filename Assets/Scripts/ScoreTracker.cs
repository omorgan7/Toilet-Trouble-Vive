using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	public Text score;
	public GameObject collider;
	private int oldScore = 0;
	private int tempFontSize;
	ToiletCollisionTracker tracker;
	void Start(){
		tracker = collider.GetComponent<ToiletCollisionTracker>();
		tempFontSize = score.fontSize;

	}
	// Update is called once per frame
	void LateUpdate () {
		if(oldScore != tracker.score){
			score.fontSize = tempFontSize + 2;
			score.text = tracker.score.ToString();
			oldScore = tracker.score;
		}
		else{
			score.fontSize = tempFontSize;
		}

	}
}
