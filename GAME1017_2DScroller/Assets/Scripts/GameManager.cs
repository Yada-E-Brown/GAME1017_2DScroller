using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum States { Menu, Play, GameOver }

    public static GameManager Instance;

    public States CurrentState  = States.Menu;

    public SoundManager soundManager;

    public ScoreController scoreManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            GameObject obj = new GameObject("SoundManager");
            soundManager = obj.AddComponent<SoundManager>();
            DontDestroyOnLoad(obj);
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
    }

    public void GameOver()
    {
        CurrentState = States.GameOver;

        soundManager.PlaySfx(soundManager.deathSfx);

        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("GameScene");
        CurrentState = States.Play;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreManager = FindAnyObjectByType<ScoreController>();
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