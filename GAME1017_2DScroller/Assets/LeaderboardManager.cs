using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    GameObject LeaderboardCanvas;

    public TMP_Text[] scoreTexts;

    private void Start()
    {
        DisplayLeaderboard();
    }
    public void OpenLeaderBoadManager()
    {
        LeaderboardCanvas.SetActive(true);
        DisplayLeaderboard();
    }
    public void CloseLeaderboardCanvas()
    {
        LeaderboardCanvas.SetActive(false);
    }
    void DisplayLeaderboard()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            int score = PlayerPrefs.GetInt("Score_" + i, 0);
            scoreTexts[i].text = (i + 1) + ". " + score.ToString();
        }
    }
}
