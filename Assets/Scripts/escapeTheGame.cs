using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*PROJECT TENDERFOOT
 * Started: 01/13/21
 * Last updated: 01/13/21
*/

public class escapeTheGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
