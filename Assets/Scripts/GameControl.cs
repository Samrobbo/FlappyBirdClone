using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public Text scoreText;
    public Text highscoreText;
    public float scrollSpeed = -1.5f;

    private int score = 0;


    public static int highscore = 0;

	// Use this for initialization
	void Awake ()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scrollSpeed -= (0.025f);
        scoreText.text = "Score : " + score;
        if (score > highscore)
        {
            setHighScore(score);
        }
    }

    public int getScore()
    {
        return score;
    }

    public void setHighScore(int currentScore)
    {
        highscore = currentScore;

        highscoreText.text = "Highscore: " + highscore;

        PlayerPrefs.SetInt("Highscore", highscore);
        
        
    }
}
