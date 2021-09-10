using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 05/05/20
 * Last updated: 01/13/21
*/

public class settingsWater : MonoBehaviour
{
    public Animator settingsWaterAnim;

    public void waterUpTrue()
    {
        settingsWaterAnim.SetBool("waterUp", true);
        FindObjectOfType<audioManager>().Play("buttonGo");
    }

    public void waterUpFalse()
    {
        settingsWaterAnim.SetBool("waterUp", false);
        FindObjectOfType<audioManager>().Play("buttonBack");
        StartCoroutine(bII());
    }

    IEnumerator bII()
    {
        yield return new WaitForSeconds(1.19f);
        settingsWaterAnim.SetTrigger("backToIdle");
    }

}
