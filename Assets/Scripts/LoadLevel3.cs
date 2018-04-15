using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel3 : MonoBehaviour {

	private List<GameObject> objectsInScene = new List<GameObject>();
	private float startDelay = 2.0f;
	public static bool loaded = false;
	private GameObject toilet;
	private Vector3 V = new Vector3(0,0,1);
	private Vector3 U = new Vector3(0,1,0);
	

	// Use this for initialization
	void Awake () {

		GameObject loader;

		loader = Resources.Load("Level 3/toilet") as GameObject;
		toilet = Instantiate(loader, new Vector3(-3.170f, 0.3304f, 2.9169f), Quaternion.identity);
		toilet.transform.localScale = new Vector3(1,1.5f, 1.5f);
		
		loader = Resources.Load("Level 3/flyingSaucer") as GameObject;
		GameObject flyingSaucer = Instantiate(loader, new Vector3(-3.906f, 1.2431f, 2.42f), Quaternion.identity);
		flyingSaucer.transform.localScale = new Vector3(0.135f, 0.135f, 0.135f);
		
		loader = Resources.Load("Level 3/reversedSphere") as GameObject;
		GameObject reversedSphere = Instantiate(loader, new Vector3(-3.345f,1,1.0383f), Quaternion.identity);
		reversedSphere.transform.localScale = new Vector3(100,100,100);
		
		loader = Resources.Load("Level 3/sink") as GameObject;
		GameObject sink = Instantiate(loader, new Vector3(-1.88f, 0.408f, 2.01f), Quaternion.identity);
		sink.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
		
		loader = Resources.Load("Level 3/pictureFrame") as GameObject;		
		GameObject pictureFrame = Instantiate(loader, new Vector3(-3.442f, 1.7244f, 3.8032f), Quaternion.Euler(90, -180, 0));
		pictureFrame.transform.localScale = new Vector3(0.0878f, 0.0993f, 0.0820f);

		loader = Resources.Load("Level 3/door") as GameObject;
		GameObject door = Instantiate(loader, new Vector3(-3.294f, 0.8804f, -1.4f), Quaternion.Euler(0, 270, 270));
		door.transform.localScale = new Vector3(0.2446f, 0.1804f, 0.1804f);
	
		loader = Resources.Load("Level 3/wall1") as GameObject;
		GameObject wall1 = Instantiate(loader, new Vector3(-3.262f, 1.6276f, -1.441f), Quaternion.identity);
		wall1.transform.localScale = new Vector3(3.4594f, 3.1386f, 0.0936f);

		loader = Resources.Load("Level 3/wall2") as GameObject;
		GameObject wall2 = Instantiate(loader, new Vector3(-3.262f, 1.5848f, 3.6511f), Quaternion.identity);
		wall2.transform.localScale = new Vector3(3.4594f, 3.1386f, 0.0936f);
	
		loader = Resources.Load("Level 3/wall3") as GameObject;
		GameObject wall3 = Instantiate(loader, new Vector3(-1.5515f, 1.5848f, 1.1547f), Quaternion.Euler(0,90,0));
		wall3.transform.localScale = new Vector3(5.0897f, 3.1386f, 0.0636f);

		loader = Resources.Load("Level 3/wall4") as GameObject;
		GameObject wall4 = Instantiate(loader, new Vector3(-4.9774f, 1.5848f, 1.1652f), Quaternion.Euler(0,90,0));
		wall4.transform.localScale = new Vector3(5.0897f, 3.1386f, 0.0636f);

		loader =  Resources.Load("Level 3/light") as GameObject;
		loader.transform.localScale = new Vector3(1, -0.0334f, 1);
		GameObject light1 = Instantiate(loader, new Vector3(-3.1508f, 3.122f, -0.68f), Quaternion.identity);
		GameObject light2 = Instantiate(loader, new Vector3(-3.1508f, 3.122f, 2.56653f), Quaternion.identity);

		loader = Resources.Load("Level 3/floor") as GameObject;
		GameObject floor = Instantiate(loader, new Vector3(-3.27f, 0.0734f, 1.1074f), Quaternion.identity);
		floor.transform.localScale = new Vector3(3.472f, 0.0847f, 5.17416f);

		loader = Resources.Load("Level 3/ceiling") as GameObject;
		GameObject ceiling = Instantiate(loader, new Vector3(-3.273f, 3.169f, 1.174f), Quaternion.identity);
		ceiling.transform.localScale = new Vector3(3.4724f, 0.0846f, 5.1741f);

		loader = Resources.Load("CommonPrefabs/SteamVR") as GameObject;
		GameObject SteamVR = Instantiate(loader, new Vector3(-3.21f, 1.1f, 0.93f), Quaternion.identity);
		SteamVR.name = "SteamVR";
		
		GameObject spawnContainer = new GameObject("spawnContainer");

		GameObject spawnPoint = Resources.Load("Level 3/spawnPoint") as GameObject;
		
		GameObject spawnPointClone = Instantiate(spawnPoint, Vector3.zero, Quaternion.identity);
		spawnPointClone.name = "spawnPoint";

		SpawnController spawnController = spawnPointClone.GetComponent<SpawnController>();

		GameObject rightController = GameObject.Find("SteamVR/[CameraRig]/Controller (right)");

		if (spawnController) {
			spawnController.laser = rightController; // HTC Vive in the future.
			spawnController.container = spawnContainer;
			spawnController.physicsStopTime = 10f;
			spawnController.force = 240f;
		}

		loaded = true;
		
		objectsInScene.Add(door);
		objectsInScene.Add(wall1);
		objectsInScene.Add(wall2);
		objectsInScene.Add(wall3);
		objectsInScene.Add(wall4);
		objectsInScene.Add(ceiling);
		objectsInScene.Add(pictureFrame);
		objectsInScene.Add(sink);
		objectsInScene.Add(flyingSaucer);
		StartCoroutine(TurnOffGravity());
	}
	
	IEnumerator TurnOffGravity(){
		yield return new WaitForSeconds(startDelay);
		for(int i = 0; i < objectsInScene.Count; ++i){		
			if(objectsInScene[i].GetComponent<BoxCollider>() != null){
				objectsInScene[i].GetComponent<BoxCollider>().enabled = true;
				objectsInScene[i].GetComponent<Rigidbody>().AddForce(-V * 50.0f);
			}
		}
		toilet.GetComponent<BoxCollider>().enabled = true;
		toilet.GetComponent<Rigidbody>().AddForce(U * 75.0f);
	}

}

