using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 04/23/20
 * Last updated: 02/11/21
*/

public class boatMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject addCollide;
    public bool canMove;
    public bool dead;
    public float maxSpeed;
    public float acc;
    public float dec;

    public BoxCollider2D b1;
    public BoxCollider2D b2;
    public BoxCollider2D b3;

    private float spinRate = -150f;
    private bool facingRight;
    private float moveInput;

    private risingWaterBehav rWB;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        rWB = FindObjectOfType<risingWaterBehav>();
        dead = false;
    }

    private void Update()
    {
        if (moveInput == -1 || moveInput == 1)
        {
            speed += acc * Time.deltaTime;
            speed = Mathf.Clamp(speed, 11, maxSpeed);
        }
        else if (moveInput == 0)
        {
            speed -= dec * Time.deltaTime;
            speed = Mathf.Clamp(speed, 11, maxSpeed);
        }

        if (rWB.gameOver == true)
        {
            dead = true;
        }

        if(dead == true)
        {
            canMove = false;
            transform.Rotate(0, 0, spinRate * Time.deltaTime);
            addCollide.SetActive(false);
            b1.enabled = false;
            b2.enabled = false;
            b3.enabled = false;
        }

        if(facingRight == false && moveInput > 0)
        {
            flipSpin();
        } else if (facingRight == true && moveInput < 0)
        {
            flipSpin();
        }

        if (facingRight == false)
        {
            spinRate = 150f;
        }
        else if (facingRight == true)
        {
            spinRate = -150f;
        }
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
        }
        else if (canMove == false)
        {
            moveInput = 0;
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void flipSpin()
    {
        facingRight = !facingRight;
    }
}