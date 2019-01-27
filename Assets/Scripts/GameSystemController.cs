using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemController : MonoBehaviour {

    public float timeElapsed = 0f;
    public GameObject timeCounter;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text text = (Text)timeCounter.GetComponent<Text>();
        text.text = "Counting: " + (int) timeElapsed;

        if(timeElapsed > 60f)
        {
            GameObject.Find("Menu UI").GetComponent<GameOver>().isGameOver = true;
            Text gameOverText = (Text)GameObject.Find("GameOverText").GetComponent<Text>();
            gameOverText.text = "Out of time!";

            GameObject.Find("TimeText").active = false;
            GameObject.FindWithTag("GameOverImage").active = true;


        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
    }
}
