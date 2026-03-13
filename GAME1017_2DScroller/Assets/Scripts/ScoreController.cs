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

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameManager.States.Play)
        {
            time += Time.deltaTime;
            score.text = Mathf.Floor(time).ToString();
        }
    }

    public void HighSchoolUpdate()
    {
        currentScore = Mathf.FloorToInt(time);

        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (currentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
        }

        PlayerPrefs.Save();

        finalScoreText.text = currentScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}