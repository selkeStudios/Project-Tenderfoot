using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/05/21
 * Last updated: 02/04/21
*/

public class cloudBehaviour : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Transform cloudTransform;
    public int randLoc;

    private Transform teleportSpot;
    private Transform tele;
    private Transform dest;

    void Start()
    {
        ranductous();
        rb = GetComponent<Rigidbody2D>();
        cloudTransform = gameObject.GetComponent<Transform>();
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        teleportSpot = GameObject.FindGameObjectWithTag("cloudOut").GetComponent<Transform>();
        tele = GameObject.FindGameObjectWithTag("thingy").GetComponent<Transform>();
        dest = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("cloudIn"))
        {
            if (randLoc == 0)
            {
                cloudTransform.transform.position = new Vector2(teleportSpot.position.x, teleportSpot.position.y);
            }
            else if (randLoc == 1)
            {
                cloudTransform.transform.position = new Vector2(tele.position.x, tele.position.y);
            }
            else if (randLoc == 2)
            {
                cloudTransform.transform.position = new Vector2(dest.position.x, dest.position.y);
            }
            ranductous();
        }
    }

    void ranductous()
    {
        randLoc = Random.Range(0, 3);
    }
}
