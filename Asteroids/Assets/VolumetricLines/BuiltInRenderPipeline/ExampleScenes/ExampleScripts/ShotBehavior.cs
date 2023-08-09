using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * Time.deltaTime * 1000f;
		
		transform.position += new Vector3(transform.forward.x, transform.forward.y, 0) * Time.deltaTime * 1000f;
		
		transform.Rotate(0, 0, -90);
	}
}
