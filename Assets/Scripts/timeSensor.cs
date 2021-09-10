using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*PROJECT TENDERFOOT
 * Started: 05/14/20
 * Last updated: 05/15/20
*/

public class timeSensor : MonoBehaviour
{
    public Text Protext;
    private string allInts;

    private string time;
    private string oldSeconds;
    private string seconds;
    private int secondsInt;
    public int minutesInt;
    public int hoursInt;
    public string timeOfDay;

    void Start()
    {
        time = System.DateTime.UtcNow.ToLocalTime().ToString("MM/dd/yy     hh:mm tt");
        //print(time);
    }

    void Update()
    {
        seconds = System.DateTime.UtcNow.ToString("ss");

        if(seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }  

    public void UpdateTimer()
    {
        //secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("HH"));
        timeOfDay = System.DateTime.UtcNow.ToLocalTime().ToString("tt");
        allInts = hoursInt + ":" + minutesInt + " " + timeOfDay; 
        //print(allInts);
        //print(minutesInt);
        //print(hoursInt);
        Protext.text = allInts;
    }
}
