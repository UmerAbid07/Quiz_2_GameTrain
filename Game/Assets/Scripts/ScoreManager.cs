using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lives;
    public TextMeshProUGUI highScore;
    public int scoreX = 0;
    public int livesX = 3;
    
    public GameObject winnerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        scoreText=GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        lives=GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
        highScore=GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreX;
        lives.text = "Lives: " + livesX;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore",0);
    }
    public void score(bool isPowerHit)
    {
        if (isPowerHit)
        {
            scoreX += 500;
        }        
        if(scoreX>PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", scoreX);
        }
        
        PlayerPrefs.SetInt("HighScore", scoreX);
    }
    public void livesXx()
    {
        livesX--;
        if(livesX==0)
        {
            print("Game Over");
        }
    }
    public void winner()
    {
        winnerCanvas.SetActive(true);
    }
}
