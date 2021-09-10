using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*PROJECT TENDERFOOT
 * Started: 04/23/20
 * Last updated: 02/11/21
*/

public class pauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenue;
    public GameObject pauseButton;
    public Animator waterAnim;
    public Button pauseButt;

    public void Resume()
    {
        FindObjectOfType<audioManager>().Play("buttonBack");
        pauseButton.SetActive(true);
        pauseMenue.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        FindObjectOfType<audioManager>().Play("buttonGo");
        pauseButton.SetActive(false);
        pauseMenue.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void replay()
    {
        FindObjectOfType<audioManager>().Play("buttonGo");
        StartCoroutine(reply());
    }

    public void Quit()
    {
        FindObjectOfType<audioManager>().Play("buttonBack");
        StartCoroutine(goToMenu());
    }

    IEnumerator goToMenu()
    {
        Time.timeScale = 1f;
        waterAnim.SetTrigger("waterDown");
        yield return new WaitForSeconds(1.19f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator reply()
    {
        waterAnim.SetTrigger("waterDown");
        yield return new WaitForSeconds(1.19f);
        SceneManager.LoadScene("Game");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<musicManager>().pauseFilter();
            pauseButt.onClick.Invoke();
        }
    }
}
