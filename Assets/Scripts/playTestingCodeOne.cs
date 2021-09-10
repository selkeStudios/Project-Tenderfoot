using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/12/21
 * Last updated: 01/13/21
*/

public class playTestingCodeOne : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(form());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    IEnumerator form()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0.0f;
    }
}
