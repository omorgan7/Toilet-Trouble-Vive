using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject waterprefab;
	public int numtears = 1000;
	public float delay = 1f;
	public float force = 1f;
	public float offset = 1f;
	public GameObject laser;
	public GameObject container;

	private Vector3 offsetvec;
	private GameObject[] tears;
	private Vector3 direction;

	// Use this for initialization
	void Awake(){
		tears = new GameObject[numtears];
		//offsetvec = new Vector3(0f,0f,offset);
		for(int i = 0; i<numtears; i++){
			tears[i] = Instantiate(waterprefab);
			tears[i].transform.parent = container.transform;
			//tears[i].transform.localPosition = new Vector3(0f,0f,offset);//Vector3.zero;
			//tears[i].transform.localRotation = Quaternion.identity;
			tears[i].SetActive(false);
		}
	}

	void Start () {
			StartCoroutine(FireObject());
	}

	void Update(){
		gameObject.transform.position = laser.transform.position;
		direction = laser.transform.forward;
		offsetvec = direction*offset;
	}

	IEnumerator FireObject(){
		for(int i =0; i<numtears; i++){
			tears[i].SetActive(true);
			tears[i].transform.position = gameObject.transform.position + offsetvec;
			tears[i].GetComponent<Rigidbody>().AddForce(force*direction);
			yield return new WaitForSeconds(delay);
		}
	}

	void ResetPosition(GameObject tear){
		tear.transform.localPosition = offsetvec;
		tear.transform.localRotation = Quaternion.identity;
	}
}
