using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel1 : MonoBehaviour {
	private GameObject toilet;
	private GameObject door;
	private GameObject pictureFrame;

	private GameObject bathroom;
	private GameObject Light;
	
	void Start () {
		toilet = Resources.Load("Level 1/toilet") as GameObject;
		Instantiate(toilet, new Vector3(0.004f, -0.8f, 0.75f), Quaternion.identity);

		door = Resources.Load("Level 1/door") as GameObject;
		door.transform.localScale = new Vector3(0.16f, 0.12f, 0.18f);
		Instantiate(door, new Vector3(0.0f, -0.45f, -1.15f), Quaternion.Euler(180, 90, 90));

		pictureFrame = Resources.Load("Level 1/pictureFrame") as GameObject;
		pictureFrame.transform.localScale = new Vector3(0.07f, 0.06f, 0.07f);
		Instantiate(pictureFrame, new Vector3(-0.25f, 0.25f, 1.32f), Quaternion.Euler(90, 180, 0));

		bathroom = Resources.Load("Level 1/bathroom") as GameObject;
		bathroom.transform.localScale = new Vector3(1.2f, 1,1);
		Instantiate(bathroom, new Vector3(0, 0, 0), Quaternion.Euler(-90, 0, 90));

		Light = Resources.Load("Level 1/Light") as GameObject;
		Light.transform.localScale = new Vector3(0.2f, 1, 0.2f);
		Instantiate(Light, new Vector3(0, 0.8f, 0.75f), Quaternion.Euler(0, 0, -90));
		Instantiate(Light, new Vector3(0, 0.8f, -0.75f),  Quaternion.Euler(0, 0, -90));	
	}
}
