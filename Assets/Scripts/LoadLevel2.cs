using UnityEngine;
using UnityEngine.UI;

public class LoadLevel2 : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		GameObject loader;
		GameObject bathroom = new GameObject("Bathroom");

		loader = Resources.Load("Level 2/floor") as GameObject;
		GameObject floor = Instantiate(loader, new Vector3(0,-0.26f,-1), Quaternion.identity);
		floor.transform.localScale = new Vector3(2,1,1);
		floor.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/plane1") as GameObject;
		GameObject plane1 = Instantiate(loader, new Vector3(-2, 1.74f,-1), Quaternion.Euler(0,90,0));
		plane1.transform.localScale = new Vector3(2,2,4);
		plane1.transform.parent = bathroom.transform;

		loader =  Resources.Load("Level 2/plane2") as GameObject;
		GameObject plane2 = Instantiate(loader, new Vector3(2, 1.74f,-1), Quaternion.Euler(0,-90,0));
		plane2.transform.localScale = new Vector3(2,2,4);		
		plane2.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/plane3") as GameObject;
		GameObject plane3 = Instantiate(loader, new Vector3(0, 1.74f, 1), Quaternion.Euler(0,180,0));
		plane3.transform.localScale = new Vector3(2,2,1);
		plane3.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/plane4") as GameObject;
		GameObject plane4 = Instantiate(loader, new Vector3(0, 1.74f, -3), Quaternion.Euler(0,0,0));
		plane4.transform.localScale = new Vector3(2,2,1);		
		plane4.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/plane5") as GameObject;
		GameObject plane5 =	Instantiate(loader, new Vector3(-1.52f, 1.22f, 0.9f), Quaternion.Euler(0,180,0));
		plane5.transform.localScale = new Vector3(0.4f, 1.4f,1);
		plane5.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/plane6") as GameObject;
		GameObject plane6 = Instantiate(loader, new Vector3(1.56f, 1.22f, 0.9f), Quaternion.Euler(0,180,0));
		plane6.transform.localScale = new Vector3(0.4f, 1.4f,1);
		plane6.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/ceiling") as GameObject;
		GameObject ceiling = Instantiate(loader, new Vector3(0, 3.74f, -1), Quaternion.Euler(90,0,0));
		ceiling.transform.localScale = new Vector3(2,2,2);
		ceiling.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/cube") as GameObject;
		GameObject cube = Instantiate(loader, new Vector3(0, 1.289f, 0.97f), Quaternion.identity);
		cube.transform.localScale = new Vector3(0.8f, 0.05f,0.05f);
		cube.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/pictureFrame") as GameObject;
		GameObject pictureFrame = Instantiate(loader, new Vector3(0.354f, 1.731f, 1.082f), Quaternion.Euler(-90,0,0));
		pictureFrame.transform.localScale = new Vector3(2,1,2);

		loader = Resources.Load("Level 2/light") as GameObject;
		GameObject light = Instantiate(loader, new Vector3(0, 3.67f, -1), Quaternion.Euler(0, 0, -90));
		light.transform.localScale = new Vector3(0.2f, 1,0.2f);
		light.transform.parent = bathroom.transform;

		loader = Resources.Load("Level 2/toilet") as GameObject;
		GameObject toilet = Instantiate(loader, new Vector3(0,0,0), Quaternion.identity);
		GameObject toiletCollider = toilet.transform.Find("Collider").gameObject;

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
		SteamVR.name = "SteamVR";

		GameObject spawnContainer = new GameObject("spawnContainer");

		GameObject spawnPoint = Resources.Load("Level 2/spawnPoint") as GameObject;
		
		GameObject spawnPointClone = Instantiate(spawnPoint, Vector3.zero, Quaternion.identity);
		spawnPointClone.name = "spawnPoint";

		SpawnController spawnController = spawnPointClone.GetComponent<SpawnController>();

		GameObject rightController = GameObject.Find("SteamVR/[CameraRig]/Controller (right)"); // could be null
		GameObject leftController = GameObject.Find("SteamVR/[CameraRig]/Controller (left)"); // could be null
		GameObject eyeHMD = GameObject.Find("SteamVR/[CameraRig]/Camera (head)");

		loader = Resources.Load("Level 2/EventSystem") as GameObject;
		GameObject eventSystem = Instantiate(loader, Vector3.zero, Quaternion.identity);

		loader = Resources.Load("CommonPrefabs/HUD") as GameObject;
		GameObject hud = Instantiate(loader, Vector3.zero, Quaternion.identity);
		hud.name = "HUD";

		if (leftController) {
			HudFollower hudFollower = eventSystem.GetComponent<HudFollower>();
			hudFollower.hud = hud;
			hudFollower.toFollow = leftController;
			hudFollower.cameraTransform = eyeHMD.transform;
		}

		EarthquakeGenerator eqGen =  eventSystem.GetComponent<EarthquakeGenerator>();
		ScoreTracker scoreTracker = eventSystem.GetComponent<ScoreTracker>();

		if (eqGen) {
			eqGen.bathroom = bathroom;
			eqGen.toilet = toilet;
		}

		if (scoreTracker) {
			scoreTracker.collider = toiletCollider;
			scoreTracker.score = hud.transform.Find("ScoreNum").GetComponent<Text>();
		}

		if (spawnController) {
			spawnController.laser = rightController; // HTC Vive in the future.
			spawnController.container = spawnContainer;
			spawnController.physicsStopTime = 10f;
			spawnController.force = 240f;
		}

	}
	
}
