using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameUI : MonoBehaviour
{
    public static GameUI instance;
    [SerializeField]
    private Transform panelPos;
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    GameObject DiePanel;
    [SerializeField]
    Animator coinIconAnim;
    
    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    public void SetCoinsValue(int value)
    {
        scoreText.text = value.ToString();
        
        coinIconAnim.ResetTrigger("Bump");
        coinIconAnim.SetTrigger("Bump");
    }
    
    public void ShowDie()
    {
        DiePanel.SetActive(true);
        DiePanel.transform.DOMove(panelPos.position, 0.4f, true);
        GameManager.instance.CheckHighScore();
    }
    public void Restart()
    {
        GameManager.instance.NullScore();
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        GameManager.instance.NullScore();
        SceneManager.LoadScene(0);
    }

}
