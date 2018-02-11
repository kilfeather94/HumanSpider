using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{

    public Image splashScreen;
    public GameObject mainMenu;
    public Image fadeBlack;

    RectTransform objectRectTransform;

	void Start ()
    {
        RectTransform rTransform = splashScreen.GetComponent<RectTransform>();

        rTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

        fadeBlack = GetComponent<Image>();
	}
	

    public void DisableSplashScreen()
    {
        splashScreen.enabled = false;
        mainMenu.SetActive(true);     
    }
}
