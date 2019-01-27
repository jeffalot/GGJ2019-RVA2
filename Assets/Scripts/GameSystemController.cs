using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemController : MonoBehaviour {

    float timeElapsed = 0f;
    public GameObject timeCounter;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text text = (Text)timeCounter.GetComponent<Text>();
        text.text = "Counting: " + (int) timeElapsed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
    }
}
