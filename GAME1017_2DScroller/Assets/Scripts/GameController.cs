using UnityEngine;

public class GameController : MonoBehaviour
{
    void RestartOption()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.X))
        {
            GameManager.GetInstance().Playing();
        }
    }
    void Update()
    {
        switch (GameManager.GetInstance().GetMode())
        {
            case GameManager.States.Play:
                    GameManager.GetInstance().Playing();
                break;
            case GameManager.States.Menu:
                RestartOption();
                break;
            case GameManager.States.GameOver:
                RestartOption();
                break;

        }
        
    }
}
