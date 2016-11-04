using UnityEngine;
using System.Collections;

public class DragHandler : MonoBehaviour
{
	Vector3 dist;
	float posX;
	float posY;

	void OneginBDrag ()
	{
		dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	}

	void OnDrag ()
	{
		Debug.Log ("item is being dragged");
		Vector3 curPos = new Vector3 (
			Input.mousePosition.x - posX, 
			Input.mousePosition.y - posY, 
			dist.z);
		Vector3 objectPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.position = objectPos;
	}
}
