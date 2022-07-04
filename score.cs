using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text scoree;
    public GameObject comp;

    // Start is called before the first frame update
    void Start()
    {
        scoree = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoree.text = "Score;" + scoreValue;
        if ((SceneManager.GetActiveScene().buildIndex == 1))
        {
            if (scoreValue > 5)
            {
                comp.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (scoreValue > 11)
            {
                comp.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (scoreValue > 17)
            {
                comp.SetActive(true);
            }

        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (scoreValue > 23)
            {
                comp.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (scoreValue > 29)
            {
                comp.SetActive(true);
            }
        }
        PlayerPrefs.SetInt("highscore", scoreValue);
        //PlayerPrefs.SetString("main scene",scoree.text);
    }
    public void reset()
    {
        scoree.text = scoreValue.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
