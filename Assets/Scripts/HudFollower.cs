using UnityEngine;

public class HudFollower : MonoBehaviour {

	public GameObject hud;
	public GameObject toFollow;
	public Transform cameraTransform;
	
	// Update is called once per frame
	void Update () {
		hud.transform.position = toFollow.transform.position;

		// this doesn't work but it should.
		// hud.transform.LookAt(cameraTransform.forward, cameraTransform.up);
	}
}
