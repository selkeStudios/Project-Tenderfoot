using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/11/21
 * Last updated: 01/12/21
*/

public class settingsConfigurations : MonoBehaviour
{
    //public GameObject lightGuide;
    public GameObject waterLevelLines;
    public GameObject sunRiseSetBKND;
    public GameObject dayBKND;
    public GameObject nightBKND;

    private dataVariables dV;

    private void Start()
    {
        dV = FindObjectOfType<dataVariables>();
    }

    private void Update()
    {
        if(dV.sunRise == true || dV.sunSet == true)
        {
            sunRiseSetBKND.SetActive(true);
            dayBKND.SetActive(false);
            nightBKND.SetActive(false);
        } else if (dV.day == true)
        {
            sunRiseSetBKND.SetActive(false);
            dayBKND.SetActive(true);
            nightBKND.SetActive(false);
        } else if (dV.night == true)
        {
            sunRiseSetBKND.SetActive(false);
            dayBKND.SetActive(false);
            nightBKND.SetActive(true);
        }

        if(dV.waterLines == true)
        {
            waterLevelLines.SetActive(true);

        } else if (dV.waterLines == false)
        {
            waterLevelLines.SetActive(false);
        }
    }
}
