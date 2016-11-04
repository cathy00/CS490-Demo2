using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HappyBar : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text valueText;

    private int interval = 1;
    private float nextTime = 0;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            valueText.text = value + "/100";
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextTime && fillAmount > 0)
        {
            fillAmount = fillAmount - 0.01f;
            nextTime += interval;
			int a = (int) (fillAmount * 100);
			valueText.text = a + "/100";
        }
        HandleBar();
	}

    private void HandleBar() {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = fillAmount;
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
