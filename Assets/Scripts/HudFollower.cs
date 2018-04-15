using UnityEngine;

public class HudFollower : MonoBehaviour {

	public GameObject hud;
	public GameObject toFollow;
	
	// Update is called once per frame
	void Update () {
		hud.transform.position = toFollow.transform.position;
	}
}
