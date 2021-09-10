using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 05/05/20
 * Last updated: 02/11/21
*/

public class allBubbles : MonoBehaviour
{
    public bool touchingBoat = false;
    public Rigidbody2D rb;
    public Animator anim;
    public bool touchingBronze;
    public bool touchingSilver;
    public bool touchingGold;
    public float upSpeed;
    public bool beenShot;
    public bool comeBackDown;
    public bool gotOne;
    public bool destroy;
    public GameObject goldScore; //this 1 and the bottom 5 are for when 3 or more droplets are paired together
    public GameObject silverScore;
    public GameObject bronzeScore;

    public GameObject bronzeExplode;
    public GameObject silverExplode;
    public GameObject goldExplode;

    public GameObject splashEffect;
    public GameObject logicLessSplash;
    public GameObject liquifyEffect;

    public bool isRed;
    public bool isBlue;
    public bool isYellow;

    public List<GameObject> bubbleList = new List<GameObject>();
    public bool atTop;
    public bool squashed;
    public bool boat;
    public bool blank;
    public bool beeb;

    private GameObject firstBubble;
    private GameObject lastBubble;

    private scoreManager sM;
    private risingWaterBehav rWB;
    private TrailRenderer tR;
    private dataVariables dV;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.mass = 9000;
        bubbleList.Add(gameObject);
        sM = FindObjectOfType<scoreManager>();
        rWB = FindObjectOfType<risingWaterBehav>();
        atTop = false;
        squashed = true;
        tR = GetComponent<TrailRenderer>();
        tR.enabled = false;
        dV = FindObjectOfType<dataVariables>();
    }

    public void Update()
    {
        if (touchingBoat == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) //maybe .GetKey instead(?)
            {
                FindObjectOfType<audioManager>().Play("boatShot");
                rb.gravityScale = -1;
                rb.velocity = new Vector2(rb.velocity.x, upSpeed);
                bubleSh();
                beenShot = true;
            }

            StartCoroutine(trailStarter());
        }

        if(touchingGold || touchingSilver || touchingBronze)
        {
            atTop = true;
        }

        if (comeBackDown == true)
        {
            rb.gravityScale = 1;
            comeBackDown = false;
        }

        if (destroy == true)
        {
            FindObjectOfType<audioManager>().Play("combo");
            if (touchingBronze == true)
            {
                Instantiate(bronzeScore, transform.position, transform.rotation);
                sM.scoreAmount += 100;
                dV.bronzeCombos++;
            }
            else if (touchingSilver == true)
            {
                Instantiate(silverScore, transform.position, transform.rotation);
                sM.scoreAmount += 300;
                dV.silverCombos++;
            }
            else if (touchingGold == true)
            {
                Instantiate(goldScore, transform.position, transform.rotation);
                sM.scoreAmount += 500;
                dV.goldCombos++;
            }

            dV.combos++;
            dV.Save();

            foreach (GameObject bub in bubbleList) //find out why this doesn't work, in terms of instantiating them in the right places
            {
                if (touchingBronze == true)
                {
                    Instantiate(bronzeExplode, bub.transform.position, bub.transform.rotation);

                    if(gotOne == true)
                    {
                        Instantiate(bronzeExplode, bub.GetComponent<allBubbles>().firstBubble.transform.position, bub.transform.rotation);

                        if (bub.GetComponent<allBubbles>().lastBubble != null)
                        {
                            Instantiate(bronzeExplode, bub.GetComponent<allBubbles>().lastBubble.transform.position, bub.transform.rotation);
                        }
                    }
                }
                else if (touchingSilver == true)
                {
                    Instantiate(silverExplode, bub.transform.position, bub.transform.rotation);

                    if(gotOne == true)
                    {
                        Instantiate(silverExplode, bub.GetComponent<allBubbles>().firstBubble.transform.position, bub.transform.rotation);

                        if (bub.GetComponent<allBubbles>().lastBubble != null)
                        {
                            Instantiate(silverExplode, bub.GetComponent<allBubbles>().lastBubble.transform.position, bub.transform.rotation);
                        }
                    }
                }
                else if (touchingGold == true)
                {
                    Instantiate(goldExplode, bub.transform.position, bub.transform.rotation);

                    if(gotOne == true)
                    {
                        Instantiate(goldExplode, bub.GetComponent<allBubbles>().firstBubble.transform.position, bub.transform.rotation);

                        if (bub.GetComponent<allBubbles>().lastBubble != null)
                        {
                            Instantiate(goldExplode, bub.GetComponent<allBubbles>().lastBubble.transform.position, bub.transform.rotation);
                        }
                    }
                }
                bub.GetComponent<allBubbles>().bubbleItselfDestroyer();
                Destroy(bub);
            }
        }

        if(comeBackDown == true)
        {
            beenShot = false;
        }

        if(rWB.gameOver == true)
        {
            rb.gravityScale = 1f;
        }

        if(boat && blank)
        {
            Instantiate(liquifyEffect, transform.position, transform.rotation);
            FindObjectOfType<audioManager>().Play("pop");
            Destroy(gameObject);
        }

        if(firstBubble == null)
        {
            gotOne = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        allBubbles aB = collision.gameObject.GetComponent<allBubbles>();
        if (aB != null)
        {
            if (aB.touchingBoat == true && beenShot == false)
            {
                FindObjectOfType<audioManager>().Play("drop");
                Instantiate(logicLessSplash, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (aB.touchingBronze)
            {
                touchingBronze = true;
            }
            else if (aB.touchingSilver)
            {
                touchingSilver = true;
            }
            else if (aB.touchingGold)
            {
                touchingGold = true;
            }

            if(atTop == false && aB.beenShot == true)
            {
                StartCoroutine(bubbleA());
            }

            if(gameObject.GetComponent<Rigidbody2D>().gravityScale >= 1 & aB.touchingBoat == false && aB.beenShot == true)
            {
                Instantiate(liquifyEffect, transform.position, transform.rotation);
                FindObjectOfType<audioManager>().Play("pop");
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("groundWater"))
        {
            Instantiate(splashEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("bronzeBar"))
        {
            touchingBronze = true;
            StartCoroutine(bubbleA());
        }

        if (collision.gameObject.CompareTag("silverBar"))
        {
            touchingSilver = true;
            StartCoroutine(bubbleA());
        }

        if (collision.gameObject.CompareTag("goldBar"))
        {
            touchingGold = true;
            StartCoroutine(bubbleA());
        }

        if (collision.gameObject.CompareTag("dispensor"))
        {
            if (beenShot == true)
            {
                comeBackDown = true;
                beenShot = false;
            }
        }

        if (collision.gameObject.CompareTag("cusp"))
        {
            anim.SetBool("touchingBoat", true);
        }

        if (collision.gameObject.CompareTag("cusp") && collision.collider.bounds.max.x > transform.position.x)
        {
            boat = true;
        }

        if(collision.gameObject.CompareTag("blank") && collision.collider.bounds.max.x < transform.position.x)
        {
            blank = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bronzeBar"))
        {
            touchingBronze = false;
        }

        if (collision.gameObject.CompareTag("silverBar"))
        {
            touchingSilver = false;
        }

        if (collision.gameObject.CompareTag("goldBar"))
        {
            touchingGold = false;
        }

        if (collision.gameObject.CompareTag("cusp"))
        {
            boat = false;
        }

        if (collision.gameObject.CompareTag("blank"))
        {
            blank = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        allBubbles aB = collision.gameObject.GetComponent<allBubbles>();
        if (aB != null)
        {
            if (touchingBoat == false && aB.beenShot == true)
            {
                if (isRed && aB.isRed)
                {
                    Invoke("gotOney", 0.2f);
                    firstBubble = aB.gameObject;
                    bubbleList.Add(firstBubble);

                    if(gotOne == true)
                    {
                        lastBubble = aB.gameObject;
                        bubbleList.Add(lastBubble);
                        destroy = true;
                        bubbleItselfDestroyer();
                    }
                }
                else if (isBlue && aB.isBlue)
                {
                    Invoke("gotOney", 0.2f);
                    firstBubble = aB.gameObject;
                    bubbleList.Add(firstBubble);

                    if (gotOne == true)
                    {
                        lastBubble = aB.gameObject;
                        bubbleList.Add(lastBubble);
                        destroy = true;
                        bubbleItselfDestroyer();
                    }
                }
                else if (isYellow && aB.isYellow)
                {
                    Invoke("gotOney", 0.2f);
                    firstBubble = aB.gameObject;
                    bubbleList.Add(firstBubble);

                    if (gotOne == true)
                    {
                        lastBubble = aB.gameObject;
                        bubbleList.Add(lastBubble);
                        destroy = true;
                        bubbleItselfDestroyer();
                    }
                }
            }
        }

        if (collision.gameObject.CompareTag("boat"))
        {
            touchingBoat = true;
            anim.SetBool("touchingBoat", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boat"))
        {
            touchingBoat = false;
        }

        allBubbles aB = collision.gameObject.GetComponent<allBubbles>();
        if (aB != null)
        {
            if (touchingBoat == false)
            {
                if (isRed && aB.isRed)
                {
                    gotOne = false;
                }
                else if (isBlue && aB.isBlue)
                {
                    gotOne = false;
                }
                else if (isYellow && aB.isYellow)
                {
                    gotOne = false;
                }
            }
        }
    }

    void gotOney()
    {
        gotOne = true;
    }

    IEnumerator bubbleA()
    {
        if(squashed == true)
        {
            anim.SetBool("restOf", true);
            yield return new WaitForSeconds(0.1f);
            anim.SetBool("restOf", false);
        }
        squashed = false;
    }

    void bubbleItselfDestroyer()
    {
        if(touchingBronze == true)
        {
            Instantiate(bronzeExplode, transform.position, transform.rotation);
        } else if (touchingSilver == true)
        {
            Instantiate(silverExplode, transform.position, transform.rotation);
        } else if (touchingGold == true)
        {
            Instantiate(goldExplode, transform.position, transform.rotation);
        }
    }

    IEnumerator trailStarter()
    {
        yield return new WaitForSeconds(0.2f);
        tR.enabled = true;
    }

    void bubleSh()
    {
        if(beeb == false)
        {
            dV.bubblesShot++;
            dV.Save();
            beeb = true;
        }
    }
}