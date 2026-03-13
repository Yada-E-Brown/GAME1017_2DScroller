using UnityEngine;

public class GameController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.X))
        {
            if (GameManager.Instance.CurrentState == GameManager.States.Menu)
            {
                GameManager.Instance.StartGame();
            }
            if(GameManager.Instance.CurrentState == GameManager.States.GameOver)
            {
                GameManager.Instance.StartGame();
            }
        }
    }
}