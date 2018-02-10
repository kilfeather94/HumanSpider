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

    [Header("Score")]
    public Text scoreText;
    public float timeNum;

    [Header("Animators")]
    public Animator leftArmAnim;
    public Animator rightArmAnim;

    [Header("Sprites")]
    public GameObject[] mouthStates;
    public int mouthIndex;

    public KeyCode kC;

    public bool countdownDone = false;
    public bool gOver;
    public bool endGameSeq = false; //bool for End Game Coroutine sequence

    [Header("Menu UI")]
    public GameObject CountdownObj;
    public GameObject MainMenuObj;
    public GameObject EndGameObj;

    private CameraShaker camShake;

    public AudioClip GamePlayMusic;
    public AudioClip GameOverMusic;

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

        if (content.gameObject.activeSelf == true && content.value > 0f && !gOver)  
        {
            HandleBar();
            ScreenShake();
        }




        GameOver();

        if (!gOver)  // && content.gameObject.activeSelf == true
        {         
            timeNum += 1 * Time.deltaTime;
            scoreText.text = "SCORE: " + timeNum.ToString("f0");  //f0 removes decimals
        }

        
        if(endGameSeq)
        {
           
            StartCoroutine(EndGameTransition());
        }
 

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

    public void EndGameMenuToggle(bool isActive)
    {
        EndGameObj.SetActive(isActive);
    }

    public void StartGame()
    {
        if (content != null && content.gameObject.activeSelf == false)
        {
            content.gameObject.SetActive(true); // activating slider
            scoreText.gameObject.SetActive(true);
            ReInit();
            AudioSource gC_AudS = GetComponent<AudioSource>();
            gC_AudS.clip = GamePlayMusic;
            gC_AudS.Play();
        }
    }

    private void ScreenShake()
    {
        if(fill.fillAmount > 0.5f)
        {
            camShake.power = 0.1f;
            leftArmAnim.SetInteger("ArmState", 0);
            rightArmAnim.SetInteger("ArmState", 0);
            mouthStates[0].SetActive(true);
            mouthStates[1].SetActive(false);
            mouthStates[2].SetActive(false);
            mouthStates[3].SetActive(false);

            
        }
        else if (fill.fillAmount <= 0.5f && fill.fillAmount > 0.2f) // TODO Change shake intensity depending on slider value. Strong intensity when slider is 0, screen fade to black
        {
            camShake.power = 0.2f;
            leftArmAnim.SetInteger("ArmState", 1);
            rightArmAnim.SetInteger("ArmState", 1);
            mouthStates[0].SetActive(false);
            mouthStates[1].SetActive(false);
            mouthStates[2].SetActive(false);
            mouthStates[3].SetActive(true);

        }
        else if (fill.fillAmount <= 0.2f)
        {
            camShake.power = 0.5f;
        }

    }

    private void GameOver()
    {
         if(content.value <= 0f && content.gameObject.activeSelf == true) 
        {
            content.gameObject.SetActive(false);
            gOver = true;
            endGameSeq = true;
                     
        }

    }


    public void ReInit() // resetting values / variables
    {
        if (gOver)
        {
            gOver = false;
        }

        if (content.value < content.maxValue)
        {
            content.value = content.maxValue;
        }

        timeNum = 0f;
    }

    IEnumerator EndGameTransition()
    {
        endGameSeq = false;
        
        AudioSource gC_AudS = GetComponent<AudioSource>();
        gC_AudS.Stop();
        SceneFade sF = FindObjectOfType<SceneFade>();
        sF.GetComponent<Animator>().SetTrigger("endFade");
        yield return new WaitForSeconds(1f);
        gC_AudS.clip = GameOverMusic;
        gC_AudS.loop = false;
        gC_AudS.Play();
        yield return new WaitForSeconds(3f);
        camShake.power = 0.1f;
        EndGameObj.SetActive(true);
        StopCoroutine(EndGameTransition());
    }

    public void Restart()
    {
        SceneFade sF = FindObjectOfType<SceneFade>();
        sF.GetComponent<Animator>().SetTrigger("fadeIn");
        EndGameMenuToggle(false);
        CountdownObj.GetComponent<Animator>().Play("CountDown");

    }


}

