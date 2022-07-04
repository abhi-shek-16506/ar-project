using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play : MonoBehaviour
{
    public GameObject warning;
    private int SceneTocontinue;
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        //SceneManager.LoadScene("SampleScene");
    }
    public void playgame()
    {
      // SceneTocontinue = PlayerPrefs.GetInt("main scene");
       // if (SceneTocontinue != 0)
        //  {  warning.SetActive(true);}
      //  else
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("SampleScene");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
