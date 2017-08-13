using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeGenerator : MonoBehaviour {

	public GameObject Bathroom;
	public enum Axis {x,y,z};
	public Axis axis = Axis.x;
	Vector3 movementAxis;
	Vector3 toiletPos;
	Vector3 bathroomPos;
	Vector2 direction;
	public GameObject Toilet;

	public float varyingDist = 0.5f;
	public float fineDist = 0.1f;
	public float speed = 1f;



	float noise;

	void Start(){
		switch (axis){
			case(Axis.x):
				movementAxis = new Vector3(1,0,0);
				break;
			case(Axis.y):
				movementAxis = new Vector3(0,1,0);
				break;
			case(Axis.z):
				movementAxis = new Vector3(0,0,1);
				break;								
		}
		noise = fineDist;
		toiletPos = Toilet.transform.position;
		bathroomPos = Bathroom.transform.position;
	}

	void Update(){
		noise = fineDist * Random.Range(-1f,1f);
	}

	void FixedUpdate(){
		float pingpong = Mathf.PingPong(speed * Time.time + varyingDist/2f,varyingDist) - varyingDist/2f + Mathf.PingPong(Time.time,noise);
		Bathroom.transform.position = (pingpong * movementAxis) + bathroomPos;
		Toilet.transform.position = (pingpong * -1f * movementAxis) + toiletPos;
	}

}
