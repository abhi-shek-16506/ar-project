 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cONTROLL : MonoBehaviour
{
   // public Text score;
    //private int scr = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void resetthegame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if ((SceneManager.GetActiveScene().buildIndex == 1))
        {
              score.scoreValue = 0;
        }
        if ((SceneManager.GetActiveScene().buildIndex == 2))
        {
            score.scoreValue = 6;
        }
        if ((SceneManager.GetActiveScene().buildIndex == 3))
        {
            score.scoreValue = 12;
        }
        if ((SceneManager.GetActiveScene().buildIndex == 4))
        {
            score.scoreValue = 18;
        }
        if ((SceneManager.GetActiveScene().buildIndex == 5))
        {
            score.scoreValue = 24;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
