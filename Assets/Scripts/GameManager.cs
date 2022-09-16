using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    // Start is called before the first frame update
    private float spawnRate = 1f;
    public TextMeshProUGUI ScoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button exitButton;
    public bool gameActive;
    public Text TimeText;
    public float time1;
    public int lives;
    public Text livesText;

    public bool pauseMenu = true;
    public GameObject PausePanel;


    public AudioClip[] musicMenu;

    public AudioSource musicPlay;

    private void Start()
    {
        musicPlay = GetComponent<AudioSource>();
        musicPlay.PlayOneShot(musicMenu[0]);
    }
    private void Update()
    {
        Timer(time1);
        Pause(gameActive);
       
    }

    private void Pause(bool pause)
    {
        if (Input.GetKeyDown(KeyCode.Space) && pause)//true gelir kontrole girer
        {
            Time.timeScale = 0;//globalde false olur fakat alttaki sorguda pause hala true olduðu için tuþa basýldýðý zaman alttaki sorguya girmez.Ýkinci basýþta girer.
            PausePanel.SetActive(true);
            gameActive = false;//Tuþlara sýrasý ile girmektedir.
         
        }
        if (Input.GetKeyDown(KeyCode.Space) && !pause)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            gameActive = true;
        }
    }

    public string Timer(float time)
    {
        if (gameActive)
        {
            time1 -= 1 * Time.deltaTime;
            if (time <= 0)
            {
                Debug.Log("time" + time);
                _currentState = GameState.gameOver;//sayaç yapýdý sayaç bitince oyun biter
                changeState = _currentState;
            }
            return TimeText.text = "Time: " + (int)time;
        }

        return TimeText.text = "";
    }
    public enum GameState
    {
        none,
        UpdateScore,
        gameOver,
        restartGame,
        startGame,


    }
    public GameState changeState
    {
        get { return changeState; }

        set
        {
            _currentState = value;

            switch (_currentState)
            {
                case GameState.UpdateScore:

                    break;
                case GameState.gameOver:
                    gameOver();

                    break;
                case GameState.restartGame:
                    restartGame();
                    break;
                case GameState.startGame:

                    break;
            }
        }
    }

    public GameState _currentState = GameState.none;


    IEnumerator SpawnTarget()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomTargetIndex = Random.Range(0, Targets.Count);
            Instantiate(Targets[randomTargetIndex]);
            Debug.Log("Çalisti");// Thanks to the while, the loop is running continuously. If it is written in the normal method, the method will fill up because it will run very fast.

        }

    }

    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        ScoreText.text = "Score: " + score;
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        gameActive = false;

        Debug.Log("State Çalýþýyor");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Prototype 5");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void StartGame(int difficulty)
    {

        spawnRate = spawnRate / difficulty;
        gameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        livesText.text = "Lives:" + lives;
        ScoreText.text = "Score:";
        musicPlay.Stop();
        musicPlay.PlayOneShot(musicMenu[1]);
    }
}
