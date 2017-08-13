using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePhysicsDespawner : MonoBehaviour {

	//this class will stop physics calculations on anything it's attached to.
	enum TearLayer {Physics=9,Static=10};
	Rigidbody rb;

	float starttime = 0f;
	public float stopTime = 5f;
	public float collideAfter = 0.2f;
	
	void Awake () {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	public void ResetPhysics(){
		gameObject.layer = (int) TearLayer.Physics;
		rb.isKinematic = false;//physics now applies.
		//rb.detectCollisions = false;
		starttime = Time.time;
	}

	void Start(){
		ResetPhysics();
	}

	void FixedUpdate(){
		float duration = Time.time - starttime;
		if(duration >= stopTime){
			gameObject.layer = (int) TearLayer.Static;
			rb.isKinematic = true; //physics no longer applies
		}
	}
}
