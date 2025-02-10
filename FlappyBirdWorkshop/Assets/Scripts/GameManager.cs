using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Menu,
        Playing,
        GameOver
    }

    public static GameManager Instance;

    public State state = State.Menu;

    public SpriteRenderer gameOver;
    public SpriteRenderer startGame;

    public Bird bird;
    public PipeSpawner pipeSpawner;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    private int bestScore;

    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        scoreText.text = "";
        gameOver.enabled = false;
        bestScore = PlayerPrefs.GetInt("best", 0);
        bestScoreText.text = "best: " + bestScore;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Menu:
            {
                if (Input.GetButtonDown("Jump"))
                {
                    bird.StartGame();
                    score = 0;
                    startGame.enabled = false;
                    scoreText.text = score.ToString();
                    state = State.Playing;
                }

                break;
            }
            case State.Playing:
                break;
            case State.GameOver:
                if (Input.GetButtonDown("Jump"))
                {
                    SceneManager.LoadScene("SampleScene");
                }

                break;
        }
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        state = State.GameOver;
        gameOver.enabled = true;
        pipeSpawner.enabled = false;
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("best", bestScore);
        }
    }
}