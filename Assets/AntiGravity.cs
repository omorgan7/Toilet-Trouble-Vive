using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour {
	public GameObject bathroom;
	public GameObject toiletCube;
	public GameObject toilet;
	private Transform[] bathroomObjects ;
	private int numberOfObjects;
	private float startDelay = 1f;

	// Use this for initialization
	void Start () {

		numberOfObjects = bathroom.transform.childCount;
		bathroomObjects = new Transform [numberOfObjects];
		print(bathroom.transform.GetChild(0)==null);
		print(numberOfObjects);
		for(int i =0; i<numberOfObjects; ++i){
			bathroomObjects[i] = bathroom.transform.GetChild(i);
		}
		StartCoroutine(TurnOffGravity());
	}
	
	IEnumerator TurnOffGravity(){
		yield return new WaitForSeconds(startDelay);
		for(int i=0; i<numberOfObjects;++i){
			if(bathroomObjects[i].GetComponent<BoxCollider>()!=null){
				bathroomObjects[i].GetComponent<BoxCollider>().enabled = true;
				bathroomObjects[i].GetComponent<Rigidbody>().AddForce(transform.forward*15);
			}
		}
		toiletCube.GetComponent<BoxCollider>().enabled = true;
		toilet.GetComponent<Rigidbody>().AddForce(transform.forward*5);
	}

}
