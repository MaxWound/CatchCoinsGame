using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    TMP_Text highScoreText;
    private int HighScore;
    private int CurrentScore;
    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        if (PlayerPrefs.HasKey("HighScore") == false)
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
            HighScore = 0;
        }
        else
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
    }
    public void CheckHighScore()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }
    public void OperateScore(int value)
    {
        CurrentScore += value;
        GameUI.instance.SetCoinsValue(CurrentScore);
    }
    public void NullScore()
    {
        CurrentScore = 0;
    }
    

}
