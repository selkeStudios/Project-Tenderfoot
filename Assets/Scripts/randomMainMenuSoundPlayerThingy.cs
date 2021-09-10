using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 02/04/21
 * Last updated: 02/04/21
*/

public class randomMainMenuSoundPlayerThingy : MonoBehaviour
{
    //gives out a random value for a random seagull sound to play, every few seconds
    public int randSeagull;
    public int randTimeForGull;
    public float settingGull;


    // Start is called before the first frame update
    void Start()
    {
        seaGullRand();
    }

    private void Update()
    {
        settingGull -= Time.deltaTime;
        if(settingGull <= 0)
        {
            if (randSeagull == 0)
            {
                FindObjectOfType<audioManager>().Play("seagull1");
            }
            else if (randSeagull == 1)
            {
                FindObjectOfType<audioManager>().Play("seagull2");
            }
            else if (randSeagull == 2)
            {
                FindObjectOfType<audioManager>().Play("seagull3");
            }
            seaGullRand();
        }
    }

    void seaGullRand()
    {
        randTimeForGull = Random.Range(0, 20);
        randSeagull = Random.Range(0, 3);
        settingGull = randTimeForGull;
    }
}
