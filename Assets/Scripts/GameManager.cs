using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI winner;

    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject playerLPaddle;
    public GameObject playerLGoal;

    [Header("Player2")]
    public GameObject playerRPaddle; 
    public GameObject playerRGoal;

    [Header("Score")]
    public GameObject player1Text;
    public GameObject player2Text;

    private int Player1Score = 0;
    private int Player2Score = 0;
    public GameObject pausePanel;

    public void Player1Scored()
    {
        Player1Score++;
        player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        if (Player1Score % 3 == 0 && Player1Score > Player2Score)
        {
            winner.text = "Player 1 has Won!";
            Debug.Log("Player 1 has Won!");
            Pause();
        }
        ResetPosition();
    }

    public void Player2Scored()
    {
        Player2Score++;
        player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        if (Player2Score % 3 == 0 && Player2Score > Player1Score)
        {
            winner.text = "Player 2 has Won!";
            Debug.Log("Player 2 has Won!");
            Pause();
        }
        ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        playerLPaddle.GetComponent<PaddleL>().Reset();
        playerRPaddle.GetComponent<PaddleR>().Reset();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Pong");
        Time.timeScale = 1;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void Pause() 
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
