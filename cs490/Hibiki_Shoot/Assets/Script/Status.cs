using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Status {

    [SerializeField]
    private HealthBar healthbar;

    [SerializeField]
    private HappyBar happybar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currVal;

    [SerializeField]
    private float hCurrVal;

    public float CurrVal
    {
        get
        {
            return currVal;
        }

        set
        {
            currVal = value;
            healthbar.Value = currVal;
        }
    }

    public float HCurrVal
    {
        get
        {
            return hCurrVal;
        }

        set
        {
            hCurrVal = value;
            happybar.Value = hCurrVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            maxVal = value;
            healthbar.MaxValue = maxVal;
        }
    }

    public void Initialize() {
        this.MaxVal = maxVal;
        this.CurrVal = currVal;
        this.HCurrVal = hCurrVal;
    }
}
