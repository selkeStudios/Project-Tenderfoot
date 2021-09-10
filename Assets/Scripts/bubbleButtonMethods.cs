using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/09/21
 * Last updated: 01/11/21
*/

public class bubbleButtonMethods : MonoBehaviour
{
    public bool pop;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
}
