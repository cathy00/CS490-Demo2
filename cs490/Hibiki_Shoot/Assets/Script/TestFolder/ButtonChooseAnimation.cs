using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonChooseAnimation : MonoBehaviour {

    // Definition
    int CONDITION_BUTTON_POS = 1;

    // Common-Use Field

    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private GameObject ball;

    // Common-Use variables

    private int counter;
    private float fillAmount = 0.0f;
    private int kwidth = Screen.width;
    private int kheight = Screen.height;
    private float distanceToCamera = 10f;
    private Image currMask = null;
    private Transform currTrans = null;


    // Special-Use Field

    [SerializeField]
    private GameObject conditionBtn;

    [SerializeField]
    private Image conditionMask;

    public Transform conditionTransform;
    public bool isInventory = false;



    // Use this for initialization
    void Start () {
        counter = 0;
        fillAmount = 0.0f;
        cursor.transform.position = new Vector2(Screen.width/2, Screen.height/2);
    }
	
	// Update is called once per frame
	void Update () {
        cursor.transform.position = kinectToReal(ball.transform.position);
        if (isCursorEnter() == 1)
        {
            actMouseAnim(conditionMask, conditionTransform);
        }
        else
        {
            if (currMask != null)
            {
                currMask.gameObject.SetActive(false);
            }
            if (currTrans != null)
            {
                currTrans.gameObject.SetActive(false);
            }
        }
    }

    void ResetCounter() {
        counter = 0;
        fillAmount = 0.0f;
    }

    int isCursorEnter() {
        Vector2 pos = cursor.transform.position;
        // Condition
        if (120 >= pos.x && 20 <= pos.x && kheight-20 >= pos.y && kheight-120 <= pos.y)
        {
            return CONDITION_BUTTON_POS;
        }
        return -1;
    }

    void actMouseAnim(Image mask, Transform trans) {
        if (counter == 100)
        {
            trans.gameObject.SetActive(true);
            mask.gameObject.SetActive(false);
            currTrans = trans;
            currMask = null;
            counter = 0;
        }
        else {
            currMask = mask;
            counter++;
            fillAmount += 0.01f;
            mask.gameObject.SetActive(true);
            mask.fillAmount = fillAmount;
        }
    }

    Vector2 kinectToReal(Vector2 pos) {
        float realX = ( pos.x + 33.5f ) * kwidth / 67;
        float realY = ( pos.y + 14.5f ) * kheight / 29;
        Vector2 realPos = new Vector2(realX, realY);
        return realPos;
    }
}
