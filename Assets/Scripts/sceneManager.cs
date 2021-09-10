using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*PROJECT TENDERFOOT
 * Started: 05/05/20
 * Last updated: 01/13/21
*/

public class sceneManager : MonoBehaviour
{
    public Animator waterAnim;
    public GameObject ts;

    public int sunRiseHour; //5 AM - 8 AM
    public int sunRiseMinute;
    //public string sunRisett;

    public int dayHour; //8 AM - 17 PM
    public int dayMinute;
    //public string daytt;

    public int sunSetHour; //17 PM - 20 PM
    public int sunSetMinute;
    //public string sunSetTt;

    public int nightHour; //20 PM - 5 AM
    public int nightMinute;
    //public string nightTT;

    public int midNightHour; //12 AM/0

    private dataVariables dV;

    private void Start()
    {
        dV = FindObjectOfType<dataVariables>();
    }

    public void goToGame()
    {
        waterAnim.SetTrigger("waterDown");
        FindObjectOfType<audioManager>().Play("buttonGo");
        //make a Christmas/snow Stage as well???
        if (dV.timeCycle == true)
        {
            if (ts.GetComponent<timeSensor>().hoursInt >= sunRiseHour && ts.GetComponent<timeSensor>().minutesInt >= sunRiseMinute && ts.GetComponent<timeSensor>().hoursInt < dayHour)
            {
                dV.sunRise = true;
                dV.day = false;
                dV.sunSet = false;
                dV.night = false;
            }
            else if (ts.GetComponent<timeSensor>().hoursInt >= dayHour && ts.GetComponent<timeSensor>().minutesInt >= dayMinute && ts.GetComponent<timeSensor>().hoursInt < sunSetHour)
            {
                dV.sunRise = false;
                dV.day = true;
                dV.sunSet = false;
                dV.night = false;
            }
            else if (ts.GetComponent<timeSensor>().hoursInt >= sunSetHour && ts.GetComponent<timeSensor>().minutesInt >= sunSetMinute && ts.GetComponent<timeSensor>().hoursInt < nightHour)
            {
                dV.sunRise = false;
                dV.day = false;
                dV.sunSet = true;
                dV.night = false;
            }
            else if (ts.GetComponent<timeSensor>().hoursInt >= nightHour && ts.GetComponent<timeSensor>().minutesInt >= nightMinute && ts.GetComponent<timeSensor>().hoursInt >= sunSetHour)
            {
                dV.sunRise = false;
                dV.day = false;
                dV.sunSet = false;
                dV.night = true;
            }
            else if (ts.GetComponent<timeSensor>().hoursInt >= midNightHour && ts.GetComponent<timeSensor>().minutesInt >= nightMinute && ts.GetComponent<timeSensor>().hoursInt < sunRiseHour)
            {
                dV.sunRise = false;
                dV.day = false;
                dV.sunSet = false;
                dV.night = true;
            }
        }
        StartCoroutine(gameScene());
    }

    IEnumerator gameScene()
    {
        yield return new WaitForSeconds(1.19f);
        SceneManager.LoadScene("Game");
    }
}
