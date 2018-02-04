using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

 
    public float currStrength;
    public float maxStrength;
    public float recoveryRate;

    public Slider content;

    public KeyCode kC;

   public bool countdownDone = false;

    public GameObject CountdownObj;
    public GameObject MainMenuObj;

    void Start ()
    {
		
	}
	

	void Update ()
    {
    
        if(Input.GetKeyDown(kC))
        {
            content.value += 3.0f;
        }

        if (content.gameObject.activeSelf == true)
        {
            HandleBar();
        }
    }

    private void HandleBar()
    {
        if(content.value != maxStrength)
        {
            content.value = Mathf.MoveTowards(content.value, maxStrength, recoveryRate * Time.deltaTime);
           
        }
    }

    public void StartCountDown()
    {
        if(CountdownObj != null && CountdownObj.activeSelf == false)
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
}
