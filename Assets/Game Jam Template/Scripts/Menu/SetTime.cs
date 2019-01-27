using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetTime : MonoBehaviour {


	public void timeSlider(float musicLvl)
	{
        Debug.Log("Pausing Time 3");
    
        Time.timeScale = musicLvl;
    }
    
}
