using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*PROJECT TENDERFOOT
 * Started: 02/06/21
 * Last updated: 02/06/21 
*/

public class variableToText : MonoBehaviour
{
    public Text bubbleS;
    public Text tides;
    public Text overall;
    public Text gold;
    public Text silver;
    public Text bronze;
    public Text death;

    private dataVariables dV;

    void Start()
    {
        dV = FindObjectOfType<dataVariables>();
    }

    void Update()
    {
        bubbleS.text = dV.bubblesShot.ToString();
        tides.text = dV.timesTide.ToString();
        overall.text = dV.combos.ToString();
        gold.text = dV.goldCombos.ToString();
        silver.text = dV.silverCombos.ToString();
        bronze.text = dV.bronzeCombos.ToString();
        death.text = dV.deaths.ToString();
    }
}
