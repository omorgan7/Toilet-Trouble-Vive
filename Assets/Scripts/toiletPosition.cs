using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toiletPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < 0f){
			print("below zero");
			gameObject.transform.GetComponent<Rigidbody>().AddForce(0f,1f,0f);
		}
		
	}
}
