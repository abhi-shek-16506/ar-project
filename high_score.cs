using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class high_score : MonoBehaviour
{
    public  Text highscoree;
    // Start is called before the first frame update
    void Start()
    {
       highscoree.text =PlayerPrefs.GetString("highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
