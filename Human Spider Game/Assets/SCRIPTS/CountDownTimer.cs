using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

    private GameController gC;
    public AudioClip countSound;

    private AudioSource c_audS;

    void Start()
    {
        c_audS = FindObjectOfType<AudioSource>();
    }


    public void EndCountDown() // Starts Game
    {
        gC = FindObjectOfType<GameController>();
        gC.countdownDone = true; // flag set to true, so gameplay can begin
        gC.StartGame();
    }

    public void PlayCountSound()
    {
        c_audS.PlayOneShot(countSound);
    }
}
