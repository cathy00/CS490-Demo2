using UnityEngine;
using System.Collections;

public class CatAnimationController : MonoBehaviour {

	public Animator cat_animator;
	public GameObject donuts;
	public GameObject hambuger;
	public GameObject milk;
	public GameObject medicine;
	public GameObject towel;
	public GameObject ball;

	private bool move = false;
	private bool stillEating = false;
	private float secondx;
	private float secondy;
	private float secondz;
	private Vector3 secondPosition;
	private GameObject currentActivated;
	private Vector3 defaultPosition;

	// Use this for initialization
	void Start () {
		cat_animator = GetComponent<Animator> ();
		move = false;
		stillEating = false;
		currentActivated = null;
		defaultPosition = donuts.transform.position;
		Debug.Log ("CatAnimationController : " + defaultPosition);
	}

	// Update is called once per frame
	void Update () {
		
		ActivatedObject ();

		if (currentActivated != null && !move && !stillEating && currentActivated.transform.position.y <= -5) {
			readyToMove ();
		}
//		Debug.Log (currentActivated.transform.position.y);
		if (currentActivated != null) {
			float secondX = currentActivated.transform.position.x;
			float secondy = transform.position.y;
			float secondz = currentActivated.transform.position.z;
			Vector3 secondPosition = new Vector3 (secondX, secondy, secondz);

			if (currentActivated == towel) {
				secondPosition = new Vector3 (0, secondy, 0);
			} 

			if (move) {
				Debug.Log ("CatAnimationController : Before : " + transform.position + " " + secondPosition); 
				transform.LookAt (secondPosition);
				cat_animator.Play ("go_position", -1);
				Debug.Log ("CatAnimationController : After : " + transform.position);
			}
			if (move && Vector3.Distance (transform.position, secondPosition) <= 2.5f) {
				if (currentActivated == ball) {
					move = false;
					StartCoroutine (playAction ());
				} else {
					move = false;
					StartCoroutine (EndAction ());
				}
			}
		}
	}

	void readyToMove () {
		StartCoroutine (userAction ());
		move = true;
		stillEating = true;
	}

	void ActivatedObject () {
		if (donuts.gameObject.activeSelf == true) {
			currentActivated = donuts;
		} else if (hambuger.gameObject.activeSelf == true) {
			currentActivated = hambuger;
		} else if (milk.gameObject.activeSelf == true) {
			currentActivated = milk;
		} else if (medicine.gameObject.activeSelf == true) {
			currentActivated = medicine;
		} else if (towel.gameObject.activeSelf == true) {
			currentActivated = towel;
		} else if (ball.gameObject.activeSelf == true) {
			currentActivated = ball;
		} 
	}

	IEnumerator EndAction()
	{
		move = false;
		cat_animator.Play ("eat", -1);
		yield return new WaitForSeconds(1.5f);
		currentActivated.SetActive (false);
		currentActivated.transform.position = defaultPosition;
		stillEating = false;
		currentActivated = null;
	}

	IEnumerator playAction()
	{
		move = false;
		cat_animator.Play ("playRepeat", -1);
		yield return new WaitForSeconds(3f);
		cat_animator.Play ("play", -1);
		currentActivated.SetActive (false);
		currentActivated.transform.position = defaultPosition;
		stillEating = false;
		currentActivated = null;
	}

	IEnumerator washAction()
	{
		move = false;
		cat_animator.Play ("wash", -1);
		yield return new WaitForSeconds(3f);
		cat_animator.Play ("washEnd", -1);
		currentActivated.SetActive (false);
		currentActivated.transform.position = defaultPosition;
		stillEating = false;
		currentActivated = null;
	}

	IEnumerator userAction()
	{
		yield return new WaitForSeconds(8f);
		readyToMove ();
	}
}
