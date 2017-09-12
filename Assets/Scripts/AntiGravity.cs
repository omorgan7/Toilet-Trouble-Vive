using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour {
	public GameObject bathroom;
	public GameObject toiletCube;
	public GameObject UFO;
	public GameObject toilet;
	public GameObject walls;
	private Transform[] bathroomWalls;
	private int numberOfwalls;
	private Transform[] bathroomObjects ;
	private int numberOfObjects;
	private float startDelay = 3f;

	private SpawnController SC;

	// Use this for initialization
	void Start () {

		numberOfObjects = bathroom.transform.childCount;
		bathroomObjects = new Transform [numberOfObjects];
		numberOfwalls = walls.transform.childCount;
		bathroomWalls = new Transform [numberOfwalls];
		for(int i =0; i<numberOfObjects; ++i){
			bathroomObjects[i] = bathroom.transform.GetChild(i);
		}
		for(int i = 0; i<numberOfwalls;++i){
			bathroomWalls[i] = walls.transform.GetChild(i);
		}
		GameObject SP = GameObject.Find("SpawnPoint");
		SC= SP.GetComponent<SpawnController>();
		StartCoroutine(TurnOffGravity());
	}
	
	IEnumerator TurnOffGravity(){
		yield return new WaitForSeconds(startDelay);
		for(int i=0; i<numberOfObjects;++i){
			if(bathroomObjects[i].GetComponent<BoxCollider>()!=null){
				bathroomObjects[i].GetComponent<BoxCollider>().enabled = true;
			}
		}
		for(int i=0; i<numberOfwalls;++i){
			if(bathroomWalls[i].GetComponent<BoxCollider>()!=null){
				var normal = bathroomWalls[i].GetComponent<MeshFilter>().mesh.normals[i]; 
				bathroomWalls[i].GetComponent<BoxCollider>().enabled = true;
				bathroomWalls[i].GetComponent<Rigidbody>().AddForce(-normal*50);
			}
		}
		toiletCube.GetComponent<BoxCollider>().enabled = true;
		for(int i=0; i<SC.getNumTears(); ++i){
			SpawnController.tearrb[i].useGravity=false;
		}
		UFO.GetComponent<Rigidbody>().AddForce(-4f,0f,0f);

	}

}
