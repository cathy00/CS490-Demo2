using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonChooseAnimation : MonoBehaviour {
    private int kwidth = Screen.width;
    private int kheight = Screen.height;

    [SerializeField]
    private Image mask;

    

    [SerializeField]
    private GameObject conditionBtn;

    // Common-Use Field
    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private GameObject ball;

    // Common-Use variables
    private int counter;
    private float fillAmount = 0.0f;
    
    public Transform mytransform;
    public bool isInventory = false;

    private float distanceToCamera = 10f;


    // Use this for initialization
    void Start () {
        counter = 0;
        fillAmount = 0.0f;
        cursor.transform.position = new Vector2(Screen.width/2, Screen.height/2);
    }
	
	// Update is called once per frame
	void Update () {
        cursor.transform.position = kinectToReal(ball.transform.position);
        if (mytransform.gameObject.activeSelf == false && !isInventory)
        {
            if (isCursorEnter())
            {
                counter++;
                fillAmount += 0.01f;
                if (mask != null)
                {
                    mask.gameObject.SetActive(true);
                    mask.fillAmount = fillAmount;
                }
                    
            }
            if (isCursorEnter() && 100 == this.counter)
            {
                ResetCounter();
                mytransform.gameObject.SetActive(true);
                mask.gameObject.SetActive(false);
            }
        }
        else
        {
            if (isCursorEnter())
            {
                counter++;
                fillAmount += 0.01f;
                if (mask != null)
                {
                    mask.gameObject.SetActive(true);
                    mask.fillAmount = fillAmount;
                }
            }
            if (isCursorEnter() && 100 == this.counter)
            {
                transform.parent.parent.gameObject.SetActive(false);
                // ToDo: set random position


                mytransform.gameObject.SetActive(true);
                mask.gameObject.SetActive(false);
            }
        }
    }

    void ResetCounter() {
        counter = 0;
        fillAmount = 0.0f;
    }

    bool isCursorEnter() {
        Vector2 pos = cursor.transform.position;

        // Condition
        if (120 >= pos.x && 20 <= pos.x && kheight-20 >= pos.y && kheight-120 <= pos.y)
        {
            Debug.Log("asdf");
            return true;
        }
        return false;
    }

    Vector2 kinectToReal(Vector2 pos) {
        float realX = ( pos.x + 33.5f ) * kwidth / 67;
        float realY = ( pos.y + 14.5f ) * kheight / 29;
        Vector2 realPos = new Vector2(realX, realY);
        return realPos;
    }
}
