using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float countdownTime = 60;
    float currentTime = 0;
    bool gameOver = false;
    public int round = 0;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] TMPro.TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = countdownTime;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownTimer();
    }
    private void CountDownTimer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
        else
        {
            countdownText.text = "0";
            GameOver();
        }
    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
