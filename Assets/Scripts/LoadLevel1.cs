using UnityEngine;

public class LoadLevel1 : MonoBehaviour {
	void Awake () {

		GameObject loader;

		loader = Resources.Load("Level 1/toilet") as GameObject;
		loader.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
		GameObject toilet = Instantiate(loader, new Vector3(0.004f, -2.25f, 0.9f), Quaternion.identity);

		loader = Resources.Load("Level 1/door") as GameObject;
		loader.transform.localScale = new Vector3(1.0f/3.5f, 0.175f, 0.25f);
		GameObject door = Instantiate(loader, new Vector3(0.0f, -1.5f, -1.45f), Quaternion.Euler(180, 90, 90));
		

		loader = Resources.Load("Level 1/pictureFrame") as GameObject;
		GameObject pictureFrame = Instantiate(loader, new Vector3(-0.25f, -0.4f, 1.65f), Quaternion.Euler(90, 180, 0));
		pictureFrame.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);

		loader =  Resources.Load("Level 1/bathroom") as GameObject;
		loader.transform.localScale = new Vector3(1.5f, 2.4f, 2.5f);	
		GameObject bathroom = Instantiate(loader, Vector3.zero, Quaternion.Euler(-90, 0, 90));
			

		loader = Resources.Load("Level 1/Light") as GameObject;
		loader.transform.localScale = new Vector3(1, 1, 1);
		GameObject light1 = Instantiate(loader, new Vector3(0, 2.02f, 0.7f), Quaternion.identity);
		GameObject light2 = Instantiate(loader, new Vector3(0,2.02f, -0.7f),  Quaternion.identity);

		GameObject spawnContainer = new GameObject("spawnContainer");

		GameObject spawnPoint = Resources.Load("Level 1/spawnPoint") as GameObject;
		
		GameObject spawnPointClone = Instantiate(spawnPoint, Vector3.zero, Quaternion.identity);
		spawnPointClone.name = "spawnPoint";

		GameObject steamVR = Resources.Load("CommonPrefabs/SteamVR") as GameObject;
		GameObject steamVRClone = Instantiate(steamVR, new Vector3(-0.02f, -1.08f, -0.92f), Quaternion.identity);
		steamVRClone.name = "SteamVR";
		GameObject rightController = GameObject.Find("SteamVR/[CameraRig]/Controller (right)");

		SpawnController spawnController = spawnPointClone.GetComponent<SpawnController>();
		
		if (spawnController) {
			spawnController.laser = rightController != null ? rightController : spawnPointClone;
			spawnController.container = spawnContainer;
			spawnController.physicsStopTime = 10f;
			spawnController.force = 240f;
		}
	}
}
