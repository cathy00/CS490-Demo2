using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
//		Debug.Log (transform.position + " " + transform.name);
	}

	// Update is called once per frame
	void Update () {		
//		Debug.Log (transform.position);

		if (transform.rotation.eulerAngles.y == 180 && transform.position.z < -7) {
			Debug.Log ("change direction to right");
			transform.Rotate (0, -90, 0);
		}
		else if (transform.rotation.eulerAngles.y == 90 && transform.position.x > 10) {
			Debug.Log ("change direction to back");
			transform.Rotate (0, -90, 0);
		}
		else if (transform.rotation.eulerAngles.y == 0 && transform.position.z > 10) {
			Debug.Log ("change direction to left");
			transform.Rotate (0, -90, 0);
		}
		else if (transform.rotation.eulerAngles.y == 270 && transform.position.x < -10) {
			Debug.Log ("change direction to forward");
			transform.Rotate (0, -90, 0);
		}

//		transform.Translate (Vector3.forward * Time.deltaTime);
	}
}
