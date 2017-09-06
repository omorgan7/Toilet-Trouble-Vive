using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeGenerator : MonoBehaviour {

	public GameObject Bathroom;
	public GameObject Toilet;
	public float varyingDist = 0.5f;
	public float fineDist = 0.1f;
	public float speed = 1f;

	float noise;
	float pingpong = 0f;
	Rigidbody toiletRB;
	Vector3 direction, toiletDirection, toiletPos, bathroomPos;

	void Start(){
		noise = fineDist;
		toiletPos = Toilet.transform.position;
		toiletRB = Toilet.GetComponent<Rigidbody>();
		bathroomPos = Bathroom.transform.position;
	}

	void Update(){
		noise = fineDist * Random.Range(-1f,1f);
	}

	void FixedUpdate(){
		if(pingpong <= 0.001f && pingpong >= -0.001f){
			direction = Random.insideUnitSphere;
			toiletDirection = Random.insideUnitSphere;
		}
		pingpong = Mathf.PingPong(Time.time,2f * speed)-speed;

		Bathroom.transform.position =  varyingDist*((pingpong+noise) * direction) + bathroomPos;
		//toiletRB.AddForce(varyingDist*((-1*pingpong+noise) * toiletDirection));
	}

}
