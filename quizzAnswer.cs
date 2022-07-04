using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizzAnswer : MonoBehaviour
{
    public bool iscorrect = false;
    public QUIZ quizz;
   //    public GameObject but;
   public void answer()
    {
        if(iscorrect)
        {
            Debug.Log("correct");
            quizz.correctanswer();
        }
        else
        {
            Debug.Log("wrong");
            quizz.correctanswer();
        }
    }
}
