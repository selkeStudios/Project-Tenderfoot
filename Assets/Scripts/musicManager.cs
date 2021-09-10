using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 02/11/21
 * Last updated: 02/11/21
*/

public class musicManager : MonoBehaviour
{
    public AudioSource oneTen;

    private risingWaterBehav rW;

    private void Start()
    {
        oneTen.volume = 0.45f;

        rW = FindObjectOfType<risingWaterBehav>();
    }

    private void Update()
    {
        if(rW.gameOver == true)
        {
            oneTen.volume -= Time.deltaTime / 2;
            if(oneTen.volume <= 0)
            {
                oneTen.volume = 0;
            }
        }
    }

    public void pauseFilter()
    {
        oneTen.volume = 0.15f;
    }

    public void resetFilter()
    {
        oneTen.volume = 0.45f;
    }

}
