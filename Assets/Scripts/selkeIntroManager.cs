using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*PROJECT TENDERFOOT
 * Started: 07/22/20
 * Last updated: 02/11/21
*/

public class selkeIntroManager : MonoBehaviour
{
    public GameObject quickWater;
    public GameObject trueIntroWater;
    public bool trueIntro;

    void Start()
    {
        StartCoroutine(doTheIntro());
        quickWater.SetActive(false);
        trueIntroWater.SetActive(true);
        trueIntro = true;
    }

    IEnumerator doTheIntro()
    {
        yield return new WaitForSeconds(1.08f);
        FindObjectOfType<audioManager>().Play("ssJingle");
        yield return new WaitForSeconds(6.43f); //then calculate and potentially change this value
        if(trueIntro == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void quickStart()
    {
        trueIntro = false;
        trueIntroWater.SetActive(false);
        quickWater.SetActive(true);
        StartCoroutine(quickTro());
    }

    IEnumerator quickTro()
    {
        yield return new WaitForSeconds(1.19f);
        SceneManager.LoadScene("MainMenu");
    }
}
