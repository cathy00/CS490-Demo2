using UnityEngine;
using System.Collections;

public class CatAnimationController : MonoBehaviour {

	public Animator cat_animator;
	public GameObject target;
	public bool move = false;

	// Use this for initialization
	void Start () {
		cat_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		float secondX = target.transform.position.x;
		float secondy = transform.position.y;
		float secondz = target.transform.position.z;
		Vector3 secondPosition = new Vector3(secondX, secondy, secondz);

		if (Input.GetKeyDown ("1")) {
			goPosition ();
		}

		if ( move ) {
			Debug.Log ("CatAnimationController : Before : " + transform.position + " " + secondPosition); 
			transform.LookAt (secondPosition);
			cat_animator.Play ("go_position", -1);
			Debug.Log ("CatAnimationController : After : " + transform.position);
		}

//		Debug.Log ("CatAnimationController : Distance : " +  Vector3.Distance(transform.position, secondPosition));

		if (move && Vector3.Distance(transform.position, secondPosition) <= 2.5f) {			
			move = false;
			StartCoroutine(EndAction ());
		}
	}

	void goPosition() {
		move = true;
	}

	IEnumerator EndAction()
	{
		cat_animator.Play ("eat", -1);
		yield return new WaitForSeconds(1.5f);
		target.GetComponent<Renderer>().enabled = false;
	}
}
