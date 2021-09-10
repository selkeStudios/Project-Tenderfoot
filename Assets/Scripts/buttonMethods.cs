using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*PROJECT TENDERFOOT
 * Started: 01/09/21
 * Last updated: 02/05/21
*/

public class buttonMethods : MonoBehaviour
{
    //Use this for the button methods, like bubbles and other stuff in the settings menu

    public Button minusTime;
    public Button plusTime;
    public GameObject timeCover;
    public Button timeCycleButton;
    public Button vBubble;
    public Button colorB;
    public Button waterLevel;
    public Button deleteScore;
    public Button statButton;
    public GameObject statsScreen;

    private dataVariables dV;

    private void Start()
    {
        dV = FindObjectOfType<dataVariables>();
    }

    private void Update()
    {
        if(dV.timeCycle == false)
        {
            minusTime.interactable = true;
            plusTime.interactable = true;
            timeCover.SetActive(false);
            timeCycleButton.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", true);
        } else if (dV.timeCycle == true)
        {
            minusTime.interactable = false;
            plusTime.interactable = false;
            timeCover.SetActive(true);
            timeCycleButton.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", false);
        }

        if(dV.colorBlind == true)
        {
            colorB.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", false);
        } else if (dV.colorBlind == false)
        {
            colorB.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", true);
        }

        if(dV.waterLines == true)
        {
            waterLevel.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", false);
        }
        else
        {
            waterLevel.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", true);
        }

        if (dV.vSync == false)
        {
            vBubble.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", false);
            QualitySettings.vSyncCount = 1;
        }
        else if (dV.vSync == true)
        {
            vBubble.GetComponent<bubbleButtonMethods>().anim.SetBool("isPopped", true);
            QualitySettings.vSyncCount = 0;
        }
    }

    public void changeTime()
    {
        FindObjectOfType<audioManager>().Play("pop");
        dV.timeCycle = !dV.timeCycle;
    }

    public void colorBlindness()
    {
        FindObjectOfType<audioManager>().Play("pop");
        dV.colorBlind = !dV.colorBlind;
    }

    public void levelOfAltum()
    {
        FindObjectOfType<audioManager>().Play("pop");
        dV.waterLines = !dV.waterLines;
    }

    public void verticallySyncing()
    {
        FindObjectOfType<audioManager>().Play("pop");
        dV.vSync = !dV.vSync;
    }

    public void deleteHS()
    {
        FindObjectOfType<audioManager>().Play("pop");
        deleteScore.GetComponent<Animator>().Play("broble");
        PlayerPrefs.DeleteKey("highScore");
    }

    public void statsScreeny()
    {
        FindObjectOfType<audioManager>().Play("pop");
        statButton.GetComponent<Animator>().Play("broble");
        statsScreen.SetActive(true);
    }

    public void and()
    {
        FindObjectOfType<audioManager>().Play("buttonBack");
    }

    public void or()
    {
        FindObjectOfType<audioManager>().Play("buttonGo");
    }
}
