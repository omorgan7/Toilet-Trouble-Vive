using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	public Text Score;
	public GameObject collider;

	private int oldscore = 0;
	private int tempfontsize;
	ToiletCollisionTracker tracker;
	void Start(){
		tracker = collider.GetComponent<ToiletCollisionTracker>();
		tempfontsize = Score.fontSize;

	}
	// Update is called once per frame
	void LateUpdate () {
		if(oldscore != tracker.score){
			Score.fontSize = tempfontsize + 2;
			Score.text = tracker.score.ToString();
			oldscore = tracker.score;
		}
		else{
			Score.fontSize = tempfontsize;
		}

	}
}
