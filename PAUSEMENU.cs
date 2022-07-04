using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PAUSEMENU : MonoBehaviour
{
    private int SceneTocontinue;
    public Text score;
    private int scr = 0;
    public static bool GameIsPaused = false;
    //public GameObject pausemenuui;
    public GameObject pausemenuui;
    public void pause()
    {
        pausemenuui.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void resume()
    {
        SceneTocontinue = PlayerPrefs.GetInt("main scene");
        pausemenuui.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 

    }

    // Update is called once per frame
   public void replay()
    {
        SceneManager.LoadScene(0);
        score.text = scr.ToString();
    }    
    public void quit()
    {
        SceneManager.LoadScene(0);
    }
}
