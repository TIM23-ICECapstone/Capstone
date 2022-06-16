using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    bool gameOver = false;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] TMPro.TextMeshProUGUI countdownText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}
