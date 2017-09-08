using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawner_noWalls : MonoBehaviour {
	public GameObject player;
	public void OnTriggerExit(Collider other){
		if((other.isTrigger)||(other.tag == "wall")){
			return;
		}
		other.gameObject.transform.position = player.transform.position + player.transform.forward;
	}
}
