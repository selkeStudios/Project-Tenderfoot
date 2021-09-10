using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/03/21 ~ My Birthday :)
 * Last updated: 02/05/21
*/

[System.Serializable]
public class saveData
{
    public bool colorBlind;
    public bool timeCycle;
    public bool sunRise;
    public bool day;
    public bool sunSet;
    public bool night;
    public int timeValue;
    public bool waterLines;
    public bool vSync;

    public int bubblesShot;
    public int timesTide;
    public int combos;
    public int goldCombos;
    public int silverCombos;
    public int bronzeCombos;
    public int deaths;

    public saveData(dataVariables data)
    {
        colorBlind = data.colorBlind;
        timeCycle = data.timeCycle;
        sunRise = data.sunRise;
        day = data.day;
        sunSet = data.sunSet;
        night = data.night;
        timeValue = data.timeValue;
        waterLines = data.waterLines;
        vSync = data.vSync;

        bubblesShot = data.bubblesShot;
        timesTide = data.timesTide;
        combos = data.combos;
        goldCombos = data.goldCombos;
        silverCombos = data.silverCombos;
        bronzeCombos = data.bronzeCombos;
        deaths = data.deaths;
    }
}
