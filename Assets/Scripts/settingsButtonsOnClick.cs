using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*PROJECT TENDERFOOT
 * Started: 09/15/20
 * Last updated: 01/13/21
*/
public class settingsButtonsOnClick : MonoBehaviour
{
    public Image timeSelect;

    public Sprite sunriseSprite;
    public Sprite daySprite;
    public Sprite sunsetSprite;
    public Sprite nightSprite;

    private dataVariables dV;

    private void Start()
    {
        dV = FindObjectOfType<dataVariables>();
    }

    private void Update()
    {
        if(dV.timeCycle == false)
        {
            if (dV.timeValue == 0)
            {
                timeSelect.GetComponent<Image>().sprite = sunriseSprite;
                dV.sunRise = true;
                dV.day = false;
                dV.sunSet = false;
                dV.night = false;
            }
            else if (dV.timeValue == 1)
            {
                timeSelect.GetComponent<Image>().sprite = daySprite;
                dV.sunRise = false;
                dV.day = true;
                dV.sunSet = false;
                dV.night = false;
            }
            else if (dV.timeValue == 2)
            {
                timeSelect.GetComponent<Image>().sprite = sunsetSprite;
                dV.sunRise = false;
                dV.day = false;
                dV.sunSet = true;
                dV.night = false;
            }
            else if (dV.timeValue == 3)
            {
                timeSelect.GetComponent<Image>().sprite = nightSprite;
                dV.sunRise = false;
                dV.day = false;
                dV.sunSet = false;
                dV.night = true;
            }
        }
    }

    public void addAmount()
    {
        dV.timeValue++;
        FindObjectOfType<audioManager>().Play("buttonGo");
        if (dV.timeValue > 3)
        {
            dV.timeValue = 0;
        }
    }

    public void subtractAmount()
    {
        dV.timeValue--;
        FindObjectOfType<audioManager>().Play("buttonGo");
        if (dV.timeValue < 0)
        {
            dV.timeValue = 3;
        }
    }
}
