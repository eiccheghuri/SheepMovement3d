using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance;

    [SerializeField]
    public Text score_text;

    private int _score=0;

    public void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
        }
    }//singleton

    public void IncrementScore()
    {
        _score++;
        score_text.text = "x" + _score;
    }

    public void ReloadGame()
    {


        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        Invoke("ReloadGame",3f);
    }








}//class
