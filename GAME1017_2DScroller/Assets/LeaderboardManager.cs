using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    GameObject LeaderboardCanvas;
    public void OpenLeaderBoadManager()
    {
        LeaderboardCanvas.SetActive(true);
    }
    public void CloseLeaderboardCanvas()
    {
        LeaderboardCanvas.SetActive(false);
    }
}
