using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject floor = Resources.Load("Level 2/floor") as GameObject;
		floor.transform.localScale = new Vector3(2,1,1);
		Instantiate(floor, new Vector3(0,-0.26f,-1), Quaternion.identity);

		GameObject plane1 = Resources.Load("Level 2/plane1") as GameObject;
		plane1.transform.localScale = new Vector3(2,2,4);
		Instantiate(plane1, new Vector3(-2, 1.74f,-1), Quaternion.Euler(0,90,0));

		GameObject plane2 = Resources.Load("Level 2/plane2") as GameObject;
		plane2.transform.localScale = new Vector3(2,2,4);
		Instantiate(plane2, new Vector3(2, 1.74f,-1), Quaternion.Euler(0,-90,0));

		GameObject plane3 = Resources.Load("Level 2/plane3") as GameObject;
		plane3.transform.localScale = new Vector3(2,2,1);
		Instantiate(plane3, new Vector3(0, 1.74f, 1), Quaternion.Euler(0,180,0));

		GameObject plane4 = Resources.Load("Level 2/plane4") as GameObject;
		plane4.transform.localScale = new Vector3(2,2,1);
		Instantiate(plane4, new Vector3(0, 1.74f, -3), Quaternion.Euler(0,0,0));

		GameObject plane5 = Resources.Load("Level 2/plane5") as GameObject;
		plane5.transform.localScale = new Vector3(0.4f, 1.4f,1);
		Instantiate(plane5, new Vector3(-1.52f, 1.22f, 0.9f), Quaternion.Euler(0,180,0));

		GameObject plane6 = Resources.Load("Level 2/plane6") as GameObject;
		plane6.transform.localScale = new Vector3(0.4f, 1.4f,1);
		Instantiate(plane6, new Vector3(1.56f, 1.22f, 0.9f), Quaternion.Euler(0,180,0));

		GameObject ceiling = Resources.Load("Level 2/ceiling") as GameObject;
		ceiling.transform.localScale = new Vector3(2,2,2);
		Instantiate(ceiling, new Vector3(0, 3.74f, -1), Quaternion.Euler(90,0,0));

		GameObject cube = Resources.Load("Level 2/cube") as GameObject;
		cube.transform.localScale = new Vector3(0.8f, 0.05f,0.05f);
		Instantiate(cube, new Vector3(0, 1.289f, 0.97f), Quaternion.identity);


		GameObject pictureFrame = Resources.Load("Level 2/pictureFrame") as GameObject;
		pictureFrame.transform.localScale = new Vector3(2,1,2);
		Instantiate(pictureFrame, new Vector3(0.354f, 1.731f, 1.082f), Quaternion.Euler(-90,0,0));

		GameObject light = Resources.Load("Level 2/light") as GameObject;
		light.transform.localScale = new Vector3(0.2f, 1,0.2f);
		Instantiate(light, new Vector3(0, 3.67f, -1), Quaternion.Euler(0, 0, -90));

		GameObject toilet = Resources.Load("Level 2/toilet") as GameObject;
		Instantiate(toilet, new Vector3(0,0,0), Quaternion.identity);

		GameObject sink = Resources.Load("Level 2/sink") as GameObject;
		Instantiate(sink, new Vector3(-1.8f, 0.29f, -1.95f), Quaternion.identity);
	
		GameObject fish = Resources.Load("Level 2/fish") as GameObject;
		fish.transform.localScale = new Vector3(4,4,4);
		Instantiate(fish, new Vector3(-1.624f, 0.758f, -2.169f), Quaternion.Euler(-89.9f, 23.2f, 0));
		Instantiate(fish, new Vector3(-1.624f, 0.758f, -1.901f), Quaternion.Euler(-89.9f, 0, 0));
		Instantiate(fish, new Vector3(-1.624f, 0.758f, -2.002f), Quaternion.Euler(-89.9f, -32.61f, 0));
		Instantiate(fish, new Vector3(-1.624f, 0.758f, -1.735f), Quaternion.Euler(-89.9f, 17.98f, 0));
		Instantiate(fish, new Vector3(-1.624f, 0.758f, -2.267f), Quaternion.Euler(-89.9f, 0, -18.78f));

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
