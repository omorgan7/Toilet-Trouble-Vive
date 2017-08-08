using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject waterprefab;
	public int numtears = 1000;
	public float startDelay = 1f;
	public float delay = 1f;
	public float force = 1f;
	public float offset = 1f;
	public GameObject laser;
	public GameObject container;

	private Vector3 offsetvec;
	private GameObject[] tears;
	private Vector3 direction;
	private int tearindex = 0;

	// Use this for initialization
	void Awake(){
		tears = new GameObject[numtears];
		for(int i = 0; i<numtears; i++){
			tears[i] = Instantiate(waterprefab);
			tears[i].transform.parent = container.transform;
			tears[i].SetActive(false);
		}
	}

	void Start () {
		InvokeRepeating("FireTears",startDelay,delay);
		StartCoroutine(AudioDelay());
	}

	IEnumerator AudioDelay(){
		yield return new WaitForSeconds(startDelay);
		gameObject.GetComponent<AudioSource>().Play();
	}

	void Update(){
		gameObject.transform.position = laser.transform.position;
		gameObject.transform.forward = laser.transform.forward;
		offsetvec = direction*offset;
	}

	void FireTears(){
		if(tearindex < tears.Length){
			tears[tearindex].SetActive(true);
			tears[tearindex].GetComponent<ParticlePhysicsDespawner>().ResetPhysics();
			tears[tearindex].transform.position = gameObject.transform.position;// + offsetvec;
			tears[tearindex].GetComponent<Rigidbody>().AddForce(gameObject.transform.forward*force);
			++tearindex;
		}
		else{
			gameObject.GetComponent<AudioSource>().Stop();
		}
	}

	void ResetPosition(GameObject tear){
		tear.transform.localPosition = offsetvec;
		tear.transform.localRotation = Quaternion.identity;
	}
}
