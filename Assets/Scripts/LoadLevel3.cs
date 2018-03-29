using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel3 : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GameObject toilet = Resources.Load("Level 3/toilet") as GameObject;
		toilet.transform.localScale = new Vector3(1,1.5f, 1.5f);
		Instantiate(toilet, new Vector3(-3.170f, 0.3304f, 2.9169f), Quaternion.identity);
		
		GameObject flyingSaucer = Resources.Load("Level 3/flyingSaucer") as GameObject;
		flyingSaucer.transform.localScale = new Vector3(0.135f, 0.135f, 0.135f);
		Instantiate(flyingSaucer, new Vector3(-3.906f, 1.2431f, 2.42f), Quaternion.identity);
		
		GameObject reversedSphere = Resources.Load("Level 3/reversedSphere") as GameObject;
		reversedSphere.transform.localScale = new Vector3(100,100,100);
		Instantiate(reversedSphere, new Vector3(-3.345f,1,1.0383f), Quaternion.identity);
		
		GameObject sink = Resources.Load("Level 3/sink") as GameObject;
		sink.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
		Instantiate(sink, new Vector3(-1.88f, 0.408f, 2.01f), Quaternion.identity);
		
		GameObject pictureFrame = Resources.Load("Level 3/pictureFrame") as GameObject;
		//pictureFrame.transform.localScale = new Vector3(0.0878f, f);
		Instantiate(pictureFrame, new Vector3(-3.170f, 0.3304f, 2.9169f), Quaternion.identity);
	//	
		
	}
	
	
}
