using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private Status health;

    [SerializeField]
    private Status happy;

    // Use this for initialization
    private void Awake() {
        health.Initialize();
        happy.Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (health.CurrVal >= 10)
                health.CurrVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            if (health.CurrVal < 100)
                health.CurrVal += 10;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (happy.HCurrVal < 100)
                happy.HCurrVal += 1;
        }


	}
}
