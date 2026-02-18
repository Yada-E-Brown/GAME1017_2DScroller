using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum States
    {
        Menu,
        Play,
        GameOver
    }
    private States state = States.Menu;
    private GameManager() { }
    private static GameManager gameMangagerInstance;
    public static GameManager GetInstance()
    {
        if (gameMangagerInstance == null)
        {
            gameMangagerInstance = FindAnyObjectByType<GameManager>();
        }
        return gameMangagerInstance;
    }

    //Menus
    [SerializeField]
    public GameObject startMenu;

    public GameObject gameOverMenu;

    public GameObject playerCharacter;

    public GameObject SpawnPoint;

    private void Start()
    {
        CurrentState();
        //if (this == gameMangagerInstance)
        //{
        //    Destroy(this);
        //}
        Time.timeScale = 0;
        SpawnPoint = GameObject.Find("SpawnPoint");
    }

    public void Playing()
    {
        state = States.Play;
        startMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        playerCharacter.transform.position = SpawnPoint.transform.position;
        CurrentState();
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        state = States.GameOver;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        CurrentState();

    }

    public void CurrentState()
    {
        Debug.Log("Current State is: ");
        Debug.Log(state);
    }
    public States GetMode()
    {
        return state;

    }

}