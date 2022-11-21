using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highScoreText;
    private void Awake()
    {
        
    }
    private void Start()
    {

       
        if (PlayerPrefs.HasKey("HighScore") != false)
        {
            highScoreText.text = $"{PlayerPrefs.GetInt("HighScore")}";
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
            highScoreText.text = "0";
        }
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

}
