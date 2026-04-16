using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum States { Menu, Play, GameOver }

    public static GameManager Instance;

    public States CurrentState  = States.Menu;

    public ScoreController scoreManager;

    private GameManager(){}
    public static GameManager instance = null;
    public static GameManager GameManagerInstance()
    {
        if(instance == null)
        {
            instance = FindAnyObjectByType<GameManager>();
        }
        return instance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame() 
    {
        CurrentState = States.Play;
        SceneManager.LoadScene("GameScene");
        Debug.Log("Saved Score: " + PlayerPrefs.GetInt("Score"));

        SoundManager.Instance.PlayMusic();
    }

    public void GameOver()
    {
        CurrentState = States.GameOver;

        if (scoreManager == null)
        {
            scoreManager = FindAnyObjectByType<ScoreController>();
        }

        if (scoreManager != null)
        {
            scoreManager.UpdateHighScore();
            scoreManager.SaveScoreToLeaderboard();
        }

        SceneManager.LoadScene("GameOverScene");
        SoundManager.Instance.PlaySfx(SoundManager.Instance.deathSfx);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreManager = FindAnyObjectByType<ScoreController>();

        SegmentSpawner spawner = FindAnyObjectByType<SegmentSpawner>();
        if (spawner != null)
        {
            spawner.ResetSpawner();
        }

        CameraController camera = FindAnyObjectByType<CameraController>();
        if (camera != null && camera.player == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                camera.player = player.transform;
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}