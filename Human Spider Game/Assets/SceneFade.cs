using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{

    public Image splashScreen;
    private Image fadeBlack;

	void Start ()
    {
        fadeBlack = GetComponent<Image>();
	}
	

	void Update ()
    {
		
	}

    public void DisableSplashScreen()
    {
        splashScreen.enabled = false;
    }
}
