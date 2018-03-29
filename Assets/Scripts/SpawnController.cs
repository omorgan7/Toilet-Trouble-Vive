using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject waterprefab;
	public int numtears = 1000;
	public int numtearparticles = 50;
	public float startDelay = 1f;
	public float delay = 1f;
	public float force = 1f;
	public float offset = 1f;
	public float physicsStopTime = 3f;
	public GameObject laser;
	public GameObject container;

	private Vector3 offsetvec;
	
	private GameObject[] tears;
	private ParticlePhysicsDespawner[] tearparticles;
	static public Rigidbody[] tearrb;
	private Vector3 direction;
	private int tearindex = 0;
	private int tearcount = 0;
	private AudioSource audio;

	// Use this for initialization
	
	void Awake(){
		tears = new GameObject[numtearparticles];
		tearparticles = new ParticlePhysicsDespawner[numtearparticles];
		tearrb = new Rigidbody[numtearparticles];
		for(int i = 0; i<numtearparticles; i++){
			tears[i] = Instantiate(waterprefab);
			tears[i].transform.parent = container.transform;
			tearparticles[i] = tears[i].GetComponent<ParticlePhysicsDespawner>();
			tearrb[i] = tears[i].GetComponent<Rigidbody>();
			tears[i].SetActive(false);
		}
	}

	void Start () {
		audio = gameObject.GetComponent<AudioSource>();
		InvokeRepeating("FireTears",startDelay,delay);
		StartCoroutine(AudioDelay());
	}

	IEnumerator AudioDelay(){
		yield return new WaitForSeconds(startDelay);
		audio.Play();
	}


	void Update(){
		gameObject.transform.position = laser.transform.position;
		gameObject.transform.forward = laser.transform.forward;
		offsetvec = direction*offset;
	}
	public int getNumTears(){
		return numtearparticles;
	}

	void FireTears(){
		if(tearcount < numtears){
			tears[tearindex].SetActive(true);
			tearparticles[tearindex].ResetPhysics();
			tearparticles[tearindex].stopTime = physicsStopTime;
			tears[tearindex].transform.position = gameObject.transform.position;// + offsetvec;
			print("firing with" + gameObject.transform.position.ToString());
			tearrb[tearindex].AddForce(gameObject.transform.forward*force);
			++tearindex;
			++tearcount;
			tearindex = tearindex % numtearparticles;
		}
		else{
			audio.Stop();
		}
	}

	void ResetPosition(GameObject tear){
		tear.transform.localPosition = offsetvec;
		tear.transform.localRotation = Quaternion.identity;
	}
}
