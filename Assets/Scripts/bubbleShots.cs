using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 05/05/20
 * Last updated: 02/11/21
*/

public class bubbleShots : MonoBehaviour
{
    public GameObject redBubble;
    public GameObject blueBubble;
    public GameObject yellowBubble;
    public Transform bubbleFirePt;

    public GameObject CredBubble;
    public GameObject CblueBubble;
    public GameObject CyellowBubble;

    public int randBubble;
    //public int lastBubbleValue;
    public float waitTime;
    public float startTimeBtwBubbles;
    public bool canShoot;

    private float timeBtwBubbles;
    private scoreManager sM;
    private dataVariables dV;
    private risingWaterBehav rW;

    void Start()
    {
        waitTime = 2;
        randyBubbles();
        randyTime();
        timeBtwBubbles = startTimeBtwBubbles;
        sM = FindObjectOfType<scoreManager>();
        dV = FindObjectOfType<dataVariables>();
        rW = FindObjectOfType<risingWaterBehav>();
    }

    void Update()
    {
        if (canShoot == true)
        {
            if (timeBtwBubbles <= 0)
            {
                FindObjectOfType<audioManager>().Play("dispense");
                if (randBubble == 0)
                {
                    if(dV.colorBlind == false)
                    {
                        Instantiate(redBubble, bubbleFirePt.transform.position, Quaternion.identity);

                    } else if (dV.colorBlind == true)
                    {
                        Instantiate(CredBubble, bubbleFirePt.transform.position, Quaternion.identity);
                    }
                    timeBtwBubbles = startTimeBtwBubbles;
                    randyBubbles();
                    randyTime();
                    canShoot = false;
                } else if (randBubble == 1)
                {
                    if (dV.colorBlind == false)
                    {
                        Instantiate(blueBubble, bubbleFirePt.transform.position, Quaternion.identity);
                    }
                    else if (dV.colorBlind == true)
                    {
                        Instantiate(CblueBubble, bubbleFirePt.transform.position, Quaternion.identity);
                    }
                    timeBtwBubbles = startTimeBtwBubbles;
                    randyBubbles();
                    randyTime();
                    canShoot = false;
                } else if (randBubble == 2)
                {
                    if (dV.colorBlind == false)
                    {
                        Instantiate(yellowBubble, bubbleFirePt.transform.position, Quaternion.identity);
                    }
                    else if (dV.colorBlind == true)
                    {
                        Instantiate(CyellowBubble, bubbleFirePt.transform.position, Quaternion.identity);
                    }
                    timeBtwBubbles = startTimeBtwBubbles;
                    randyBubbles();
                    randyTime();
                    canShoot = false;
                }
            } else
            {
                timeBtwBubbles -= Time.deltaTime;
            }

            if(rW.gameOver == true)
            {
                canShoot = false;
            }
        }

        if(sM.rateTimer >= 30) //1/2 a minute
        {
            waitTime = 1.75f;
            startTimeBtwBubbles = 2.5f;
        }

        if (sM.rateTimer >= 90) //1 1/2 minutes
        {
            waitTime = 1.5f;
            startTimeBtwBubbles = 2f;
        }

        if (sM.rateTimer >= 135) //2 1/4 minutes
        {
            waitTime = 1.25f;
            startTimeBtwBubbles = 1.5f;
        }

        if (sM.rateTimer >= 180) //3 minutes
        {
            waitTime = 1f;
            startTimeBtwBubbles = 1f;
        }

        if (sM.rateTimer >= 360) //6 minutes
        {
            waitTime = 0.75f;
            startTimeBtwBubbles = 0.75f;
        }

        if (sM.rateTimer >= 480) //8 minutes
        {
            waitTime = 0.5f;
            startTimeBtwBubbles = 0.5f;
        }
    }

    public void randyBubbles()
    {
        randBubble = Random.Range(0, 3);
    }

    public void randyTime()
    {
        StartCoroutine(timeWait(waitTime));
    }

    IEnumerator timeWait(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}
