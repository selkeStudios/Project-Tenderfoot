using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*PROJECT TENDERFOOT
 * Started: 01/01/21
 * Last updated: 02/04/21 
*/

public class scoreManager : MonoBehaviour
{
    public int scoreAmount;
    public Text scoreText;
    public Text highScore;
    public Text justTheScore;

    public Text yourHighScore;

    public float rateTimer;
    public bool newHighScore;

    public GameObject[] sparkles;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    private void Update()
    {
        rateTimer += Time.deltaTime;

        scoreText.text = "Score: " + scoreAmount.ToString();
        justTheScore.text = scoreAmount.ToString();

        if (scoreAmount > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", scoreAmount);
            highScore.text = scoreAmount.ToString();
            newHighScore = true;
        }

        if(newHighScore == true)
        {
            yourHighScore.text = "New High Score!";
            yourHighScore.color = Color.yellow;

            foreach(GameObject sp in sparkles)
            {
                sp.SetActive(true);
            }
        } else
        {
            foreach (GameObject sp in sparkles)
            {
                sp.SetActive(false);
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.A)) //for debugging only, comment out, later on
        {
            PlayerPrefs.DeleteKey("highScore");
        }
        */
    }
}
