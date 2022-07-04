using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QUIZ : MonoBehaviour
{
    public List<questionandanswer> qna;
    public GameObject[] option;
    public int currentquestion;
    public Text questiontext;

    private void Start()
    {
        generatequestion();
    }
    public void correctanswer()
    {
        qna.RemoveAt(currentquestion);
        generatequestion();
    }
    void setanswers()
    {
        for(int i=0;i<option.Length;i++)
        {
            option[i].GetComponent<quizzAnswer>().iscorrect = false;
            option[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentquestion].answers[i];
            if(qna[currentquestion].correctanswer==i+1)
            {
                option[i].GetComponent<quizzAnswer>().iscorrect = true;
            }
        }
    }
    void generatequestion()
    {
        if (qna.Count > 0)
        {
            currentquestion = Random.Range(0, qna.Count);
            questiontext.text = qna[currentquestion].question;
            setanswers();
        }
        else
        {
            Debug.Log("out");
        }
    }


}
