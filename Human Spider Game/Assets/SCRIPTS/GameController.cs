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

    void Start ()
    {
		
	}
	

	void Update ()
    {
    
        if(Input.GetKeyDown(kC))
        {
            content.value += 3.0f;
        }
            
        HandleBar();
    }

    private void HandleBar()
    {
        if(content.value != maxStrength)
        {
            content.value = Mathf.MoveTowards(content.value, maxStrength, recoveryRate * Time.deltaTime);
           
        }
    }
}
