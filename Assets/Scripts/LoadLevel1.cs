using UnityEngine;

public class LoadLevel1 : MonoBehaviour {
	void Awake () {

		GameObject loader;

		loader = Resources.Load("Level 1/toilet") as GameObject;
		GameObject toilet = Instantiate(loader, new Vector3(0.004f, -0.8f, 0.75f), Quaternion.identity);

		loader = Resources.Load("Level 1/door") as GameObject;
		GameObject door = Instantiate(loader, new Vector3(0.0f, -0.45f, -1.15f), Quaternion.Euler(180, 90, 90));
		door.transform.localScale = new Vector3(0.16f, 0.12f, 0.18f);

		loader = Resources.Load("Level 1/pictureFrame") as GameObject;
		GameObject pictureFrame = Instantiate(loader, new Vector3(-0.25f, 0.25f, 1.32f), Quaternion.Euler(90, 180, 0));
		pictureFrame.transform.localScale = new Vector3(0.07f, 0.06f, 0.07f);

		loader =  Resources.Load("Level 1/bathroom") as GameObject;
		GameObject bathroom = Instantiate(loader, Vector3.zero, Quaternion.Euler(-90, 0, 90));
		bathroom.transform.localScale = new Vector3(1.2f, 1,1);		

		loader = Resources.Load("Level 1/Light") as GameObject;
		loader.transform.localScale = new Vector3(0.2f, 1, 0.2f);
		GameObject light1 = Instantiate(loader, new Vector3(0, 0.8f, 0.75f), Quaternion.Euler(0, 0, -90));
		GameObject light2 = Instantiate(loader, new Vector3(0, 0.8f, -0.75f),  Quaternion.Euler(0, 0, -90));

		GameObject spawnContainer = new GameObject("spawnContainer");

		GameObject spawnPoint = Resources.Load("Level 1/spawnPoint") as GameObject;
		
		GameObject spawnPointClone = Instantiate(spawnPoint, Vector3.zero, Quaternion.identity);
		spawnPointClone.name = "spawnPoint";

		GameObject steamVR = Resources.Load("CommonPrefabs/SteamVR") as GameObject;
		GameObject steamVRClone = Instantiate(steamVR, new Vector3(-0.02f, 0.04f, -0.69f), Quaternion.identity);
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
