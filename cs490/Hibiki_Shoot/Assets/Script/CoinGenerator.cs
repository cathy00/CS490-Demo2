using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinGenerator : MonoBehaviour {

    [SerializeField]
    private Text valueText;

    private int totalCoins;

    private int interval = 60;
    private float nextTime = 0;

	// Use this for initialization
	void Start () {
        totalCoins = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextTime && totalCoins < 9999) {
            totalCoins += Random.Range(0, 10);
            valueText.text = "Coins: " + totalCoins;
            nextTime += interval;
        }
	}
}
