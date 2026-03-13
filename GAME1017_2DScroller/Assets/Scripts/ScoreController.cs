using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text score;

    public int currentScore;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    public float time;

    private void Start()
    {
        LoadHighScore();
        if (GameManager.Instance.CurrentState == GameManager.States.Play)
        {
            time = 0;
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameManager.States.Play)
        {
            time += Time.deltaTime;
            score.text = Mathf.Floor(time).ToString();
        }
    }
    public void UpdateHighScore()
    {
        currentScore = Mathf.FloorToInt(time);

        // Load current high score
        int currentHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);

        if (currentScore > currentHighScore)
        {
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
            PlayerPrefs.Save();
            currentHighScore = currentScore;
        }

        if (finalScoreText != null)
            finalScoreText.text = currentScore.ToString();

        if (highScoreText != null)
            highScoreText.text = currentHighScore.ToString();
    }

    public void LoadHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("SavedHighScore", 0);
        if (highScoreText != null)
            highScoreText.text = savedHighScore.ToString();
    }
    public void ResetScore()
    {
        time = 0;
        currentScore = 0;
        if (score != null)
            score.text = "0";
    }
}