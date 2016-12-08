using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class buttonActiveAnotherTransform : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private int counter;
	private readonly int responseTime = 100;
	private bool isPointerEnter;
	public Transform mytransform;


	// Use this for initialization
	void Start () {
		counter = 0;
		isPointerEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPointerEnter) {
			counter++;
		}
		if (isPointerEnter && responseTime == this.counter) {
			ResetCounter ();
			mytransform.gameObject.SetActive (true);
			//GameObject.Find ("dropDownButtonGroup").SetActive(true);
		}


	}

	void ResetCounter(){
		counter = 0;
	}

	public void OnPointerEnter(PointerEventData eventData){
//		Debug.Log ("Enter " + mytransform.name);
		isPointerEnter = true;
	}

	public void OnPointerExit(PointerEventData eventData){
		isPointerEnter = false;
//		Debug.Log ("Leave " + mytransform.name);
		this.ResetCounter ();
	}

}
