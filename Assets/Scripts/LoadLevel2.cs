﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel2 : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		GameObject loader;

		loader = Resources.Load("Level 2/floor") as GameObject;
		GameObject floor = Instantiate(loader, new Vector3(0,-0.26f,-1), Quaternion.identity);
		floor.transform.localScale = new Vector3(2,1,1);

		loader = Resources.Load("Level 2/plane1") as GameObject;
		GameObject plane1 = Instantiate(loader, new Vector3(-2, 1.74f,-1), Quaternion.Euler(0,90,0));
		plane1.transform.localScale = new Vector3(2,2,4);

		loader =  Resources.Load("Level 2/plane2") as GameObject;
		GameObject plane2 = Instantiate(loader, new Vector3(2, 1.74f,-1), Quaternion.Euler(0,-90,0));
		plane2.transform.localScale = new Vector3(2,2,4);		

		loader = Resources.Load("Level 2/plane3") as GameObject;
		GameObject plane3 = Instantiate(loader, new Vector3(0, 1.74f, 1), Quaternion.Euler(0,180,0));
		plane3.transform.localScale = new Vector3(2,2,1);

		loader = Resources.Load("Level 2/plane4") as GameObject;
		GameObject plane4 = Instantiate(loader, new Vector3(0, 1.74f, -3), Quaternion.Euler(0,0,0));
		plane4.transform.localScale = new Vector3(2,2,1);		

		loader = Resources.Load("Level 2/plane5") as GameObject;
		GameObject plane5 =	Instantiate(loader, new Vector3(-1.52f, 1.22f, 0.9f), Quaternion.Euler(0,180,0));
		plane5.transform.localScale = new Vector3(0.4f, 1.4f,1);

		loader = Resources.Load("Level 2/plane6") as GameObject;
		GameObject plane6 = Instantiate(loader, new Vector3(1.56f, 1.22f, 0.9f), Quaternion.Euler(0,180,0));
		plane6.transform.localScale = new Vector3(0.4f, 1.4f,1);

		loader = Resources.Load("Level 2/ceiling") as GameObject;
		GameObject ceiling = Instantiate(loader, new Vector3(0, 3.74f, -1), Quaternion.Euler(90,0,0));
		ceiling.transform.localScale = new Vector3(2,2,2);

		loader = Resources.Load("Level 2/cube") as GameObject;
		GameObject cube = Instantiate(loader, new Vector3(0, 1.289f, 0.97f), Quaternion.identity);
		cube.transform.localScale = new Vector3(0.8f, 0.05f,0.05f);

		loader = Resources.Load("Level 2/pictureFrame") as GameObject;
		GameObject pictureFrame = Instantiate(loader, new Vector3(0.354f, 1.731f, 1.082f), Quaternion.Euler(-90,0,0));
		pictureFrame.transform.localScale = new Vector3(2,1,2);

		loader = Resources.Load("Level 2/light") as GameObject;
		GameObject light = Instantiate(loader, new Vector3(0, 3.67f, -1), Quaternion.Euler(0, 0, -90));
		light.transform.localScale = new Vector3(0.2f, 1,0.2f);

		loader = Resources.Load("Level 2/toilet") as GameObject;
		GameObject toilet = Instantiate(loader, new Vector3(0,0,0), Quaternion.identity);

		loader =  Resources.Load("Level 2/sink") as GameObject;
		GameObject sink = Instantiate(loader, new Vector3(-1.8f, 0.29f, -1.95f), Quaternion.identity);
	
		loader =  Resources.Load("Level 2/fish") as GameObject;
		loader.transform.localScale = new Vector3(4,4,4);
		GameObject fish1 = Instantiate(loader, new Vector3(-1.624f, 0.758f, -2.169f), Quaternion.Euler(-89.9f, 23.2f, 0));
		GameObject fish2 = Instantiate(loader, new Vector3(-1.624f, 0.758f, -1.901f), Quaternion.Euler(-89.9f, 0, 0));
		GameObject fish3 = Instantiate(loader, new Vector3(-1.624f, 0.758f, -2.002f), Quaternion.Euler(-89.9f, -32.61f, 0));
		GameObject fish4 = Instantiate(loader, new Vector3(-1.624f, 0.758f, -1.735f), Quaternion.Euler(-89.9f, 17.98f, 0));
		GameObject fish5 = Instantiate(loader, new Vector3(-1.624f, 0.758f, -2.267f), Quaternion.Euler(-89.9f, 0, -18.78f));

		loader = Resources.Load("CommonPrefabs/SteamVR") as GameObject;
		GameObject SteamVR = Instantiate(loader, new Vector3(0, 0.43f, -1.22f), Quaternion.identity);

		GameObject spawnContainer = new GameObject("spawnContainer");

		GameObject spawnPoint = Resources.Load("Level 2/spawnPoint") as GameObject;
		
		GameObject spawnPointClone = Instantiate(spawnPoint, Vector3.zero, Quaternion.identity);
		spawnPointClone.name = "spawnPoint";

		SpawnController spawnController = spawnPointClone.GetComponent<SpawnController>();

		if (spawnController) {
			spawnController.laser = spawnContainer; // HTC Vive in the future.
			spawnController.container = spawnContainer;
			spawnController.physicsStopTime = 10f;
			spawnController.force = 240f;
		}
	}
	
}