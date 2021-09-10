using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 02/03/21
 * Last updated: 02/06/21 
*/

public class bridgeCar : MonoBehaviour
{
    public int randVroom;
    public float countUp;
    public float carSpeed;
    public GameObject headLights;
    public AudioSource driving;
    public bool drivingSound;

    private dataVariables dV;
    private Rigidbody2D rb;
    private Animator anim;
    private risingWaterBehav rWB;

    void Start()
    {
        countUp = 0;
        dV = FindObjectOfType<dataVariables>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        randVroom = Random.Range(150, 600);
        rWB = FindObjectOfType<risingWaterBehav>();
    }

    void Update()
    {
        if (dV.sunRise == true || dV.sunSet == true)
        {
            anim.SetTrigger("sunRise");
            headLights.SetActive(false);
        } else if (dV.day == true)
        {
            anim.SetTrigger("day");
            headLights.SetActive(false);
        }
        else if (dV.night == true)
        {
            anim.SetTrigger("night");
            headLights.SetActive(true);
        }

        countUp += Time.deltaTime;
        if(countUp >= randVroom)
        {
            rb.velocity = new Vector2(carSpeed, rb.velocity.y);
            if(drivingSound == false)
            {
                if(rWB.waterLevel <= 3)
                {
                    driving.Play();
                    drivingSound = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Respawn"))
        {
            Destroy(gameObject);
        }
    }
}
