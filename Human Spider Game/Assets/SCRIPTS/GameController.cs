using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [Header("Slider Values")]
    public float currStrength;
    public float maxStrength;
    public float recoveryRate;
    public float fillValue;

    [Header("Slider UI")]
    public Slider content;
    public Image fill;



    public KeyCode kC;

    public bool countdownDone = false;

    public GameObject CountdownObj;
    public GameObject MainMenuObj;

    private CameraShaker camShake;

    void Start()
    {
        camShake = GetComponent<CameraShaker>();
    }


    void Update()
    {

        fillValue = fill.fillAmount;

        if (Input.GetKeyDown(kC))
        {
            content.value += 3.0f; // TODO Decrease content.value when slider value is near top (make more difficult)
        }

        if (content.gameObject.activeSelf == true && content.value > 0f)
        {
            HandleBar();
        }

        ScreenShake();


    }


    private void HandleBar()
    {
        if (content.value != maxStrength)
        {
            content.value = Mathf.MoveTowards(content.value, maxStrength, recoveryRate * Time.deltaTime);

        }
    }

    public void StartCountDown()
    {
        if (CountdownObj != null && CountdownObj.activeSelf == false)
        {
            CountdownObj.SetActive(true);

        }
    }

    public void MainMenuToggle(bool isActive)
    {
        MainMenuObj.SetActive(isActive);
    }

    public void StartGame()
    {
        if (content != null && content.gameObject.activeSelf == false)
        {
            content.gameObject.SetActive(true); // activating slider
        }
    }

    private void ScreenShake()
    {

        if (fill.fillAmount <= 0.5f && fill.fillAmount > 0.2f) // TODO Change shake intensity depending on slider value. Strong intensity when slider is 0, screen fade to black
        {
            camShake.power = 0.2f;
        }
        else if (fill.fillAmount <= 0.2f)
        {
            camShake.power = 0.5f;
        }

    }

}

