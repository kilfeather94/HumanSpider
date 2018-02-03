using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour {

    private GameController gC;

	void Start ()
    {
		
	}
	

	public void EndCountDown() // TODO: Animation event for countdown animation clip
    {
        gC = FindObjectOfType<GameController>();
        gC.countdownDone = true; // flag set to true, so gameplay can begin
    }
}
