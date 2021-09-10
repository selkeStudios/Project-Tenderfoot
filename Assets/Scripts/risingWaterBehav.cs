using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/02/21
 * Last updated: 02/11/21
*/

public class risingWaterBehav : MonoBehaviour
{
    public float yPos;
    public float startMoving;
    public Rigidbody2D rb;
    public float minWaterLevel; //-5.14
    public float maxWaterLevel; //0.87
    public int waterLevel;
    public GameObject deathScreen;
    public bool beeb;
    public bool playDaSound;
    public bool moving;

    public bool gameOver;
    public GameObject scoreBoard;
    public GameObject pauseButton;
    public GameObject score;
    public SpriteRenderer[] eXWater; //deepWater1

    private float stopMoving;
    private dataVariables dV;
    private scoreManager sM;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stopMoving = 0;
        gameOver = false;
        dV = FindObjectOfType<dataVariables>();
        sM = FindObjectOfType<scoreManager>();
        moving = false;
    }

    private void Update()
    {
        if(waterLevel >= 7)
        {
            gameOver = true;
            deathRate();
        }

        if (gameOver == true)
        {
            StartCoroutine(deafScree());
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        allBubbles aB = c.gameObject.GetComponent<allBubbles>();
        if (aB != null)
        {
            if (moving == false && aB.beenShot == false)
            {
                dV.timesTide++;
                dV.Save();
                waterLevel++;
                FindObjectOfType<audioManager>().Play("tide");
                StartCoroutine(waterRise());
            }

            if(moving == true && aB.beenShot == false)
            {
                FindObjectOfType<audioManager>().Play("drop");
            }
        }
    }

    IEnumerator waterRise()
    {
        if(gameObject.transform.position.y >= minWaterLevel && gameObject.transform.position.y < maxWaterLevel)
        {
            rb.velocity = new Vector2(rb.velocity.x, yPos);
            moving = true;
            yield return new WaitForSeconds(startMoving);
            rb.velocity = new Vector2(rb.velocity.x, stopMoving);
            moving = false;
        }
    }

    IEnumerator deafScree()
    {
        foreach(SpriteRenderer s in eXWater)
        {
            s.sortingOrder = 5;
        }
        rb.velocity = new Vector2(rb.velocity.x, yPos);
        if (gameObject.transform.position.y >= 4.35)
        {
            rb.velocity = new Vector2(rb.velocity.x, stopMoving);
            scoreBoard.GetComponent<Animator>().SetTrigger("fading");
            score.GetComponent<Animator>().SetTrigger("fading");
            pauseButton.GetComponent<Animator>().SetTrigger("fading");
        }
        yield return new WaitForSeconds(1.19f);
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        if (playDaSound == false)
        {
            if(sM.newHighScore == false)
            {
                FindObjectOfType<audioManager>().Play("gameOver");
            } else if (sM.newHighScore == true)
            {
                FindObjectOfType<audioManager>().Play("brighterGo");
            }
            playDaSound = true;
        }
    }

    void deathRate()
    {
        if(beeb == false)
        {
            dV.deaths++;
            dV.Save();
            beeb = true;
        }
    }
}
