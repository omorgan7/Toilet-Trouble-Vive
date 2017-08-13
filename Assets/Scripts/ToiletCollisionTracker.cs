using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletCollisionTracker : MonoBehaviour {

	public int score{
		get;
		set;
	}

	void Start(){
		score = 0;
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "tear"){
			++score;
			other.gameObject.GetComponent<AudioSource>().Play();
		}
	}
}
