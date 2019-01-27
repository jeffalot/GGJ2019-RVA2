using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetTime : MonoBehaviour {


	public void timeSlider(float musicLvl)
	{
        Time.timeScale = musicLvl;
    }
    
}
