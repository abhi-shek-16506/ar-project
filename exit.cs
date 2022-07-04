using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    private int currentsceneindex;

    public void OnMouseDown()
    {
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("main scene", currentsceneindex);
        SceneManager.LoadScene(0);
        
        //SceneManager.LoadScene("main scene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
