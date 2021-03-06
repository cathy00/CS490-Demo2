﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonActiveAnotherTransform : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField]
	private Image mask;

	private float fillAmount = 0.0f;

	private int counter;
	private readonly int responseTime = 100;
	private bool isPointerEnter;
	public Transform mytransform;

	public bool isInventory = false;


	// Use this for initialization
	void Start () {
		counter = 0;
		fillAmount = 0.0f;
		isPointerEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (mytransform.gameObject.activeSelf == false && !isInventory) {
			if (isPointerEnter) {
				counter++;
				fillAmount += 0.01f;
				if (mask != null)
					mask.fillAmount = fillAmount;
			}
			if (isPointerEnter && responseTime == this.counter) {
				ResetCounter ();
				mytransform.gameObject.SetActive (true);
				mask.gameObject.SetActive (false);
			}
		} else {
			if (isPointerEnter) {
				counter++;
				fillAmount += 0.01f;
				if (mask != null)
					mask.fillAmount = fillAmount;
			}
			if (isPointerEnter && responseTime == this.counter) {
				transform.parent.parent.gameObject.SetActive (false);
				mytransform.gameObject.SetActive (true);
				mask.gameObject.SetActive (false);
			}
		}
	}

	void ResetCounter(){
		counter = 0;
		fillAmount = 0.0f;
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
