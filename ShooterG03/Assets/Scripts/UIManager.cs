using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _timerTxt;
    public TMPro.TextMeshProUGUI _scoreTxt;
    public GameObject _loseScreen;
    public TMPro.TextMeshProUGUI _loseScreenScore;
    public Image[] _hpIndicators;

  
    void Update()
    {
        _timerTxt.text = "Time: " + Time.time.ToString("00:00");
    }
    public void SetScore(int score)
    {
        _scoreTxt.text = "Score: " + score.ToString();
    }
    public void SetHp(int newHp)
    {
        for (int i = 0; i < _hpIndicators.Length; i++)
        {
            if(newHp > i)
            {
                _hpIndicators[i].gameObject.SetActive(true);
            }else
            {
                _hpIndicators[i].gameObject.SetActive(false);
            }
        }
    }
    public void ShowLoseScreen (int score)
    {
        _loseScreen.SetActive(true);
        _loseScreenScore.text = "Score: " + score.ToString();
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// load scene hien tai
        Time.timeScale = 1;
    }
}
