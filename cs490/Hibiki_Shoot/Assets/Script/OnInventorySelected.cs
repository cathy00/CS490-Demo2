using UnityEngine;
using System.Collections;

public class OnInventorySelected : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		Debug.Log ("OnInventorySelected : item selected - " + transform.name);
		if (transform.name == "item_1") {
			ChangeItemOutlook ("Donuts");
		} else if (transform.name == "item_2") {
			ChangeItemOutlook ("Hambuger");
		}

	}

	void ChangeItemOutlook ( string itemName ) {
		Material newMaterial = Resources.Load (itemName, typeof(Material)) as Material;
		Debug.Log ("OnInventorySelected : material - " + newMaterial);
		Texture newTexture = Resources.Load (itemName, typeof(Texture)) as Texture;
		target.GetComponent<Renderer> ().material = newMaterial;
		target.GetComponent<Renderer> ().material.mainTexture = newTexture;
	}
}
