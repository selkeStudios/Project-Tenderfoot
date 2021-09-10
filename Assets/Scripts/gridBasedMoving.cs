using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/21/21
 * Last updated: 01/21/21
*/

public class gridBasedMoving : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;
    public float moveInput;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(moveInput) == 1f)
            {
                movePoint.position += new Vector3(moveInput, 0f, 0f);
            }
        }
    }
}
