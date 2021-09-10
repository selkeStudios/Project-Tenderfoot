using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/05/21
 * Last updated: 01/05/21
*/

public class impactDestroys : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 1f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
