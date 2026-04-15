using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private SaveSystem()
    {

    }
    public static SaveSystem instance = null;
    public static SaveSystem Instance()
    {
        if(instance == null)
        {
            instance = FindAnyObjectByType<SaveSystem>();
        }
        return instance;
    }
    private void Start()
    {
        
    }
    internal static void SaveScores()
    {
        PlayerPrefs.SetInt("Score", (int)GameManager.Instance.playerCharacter);
    }
}
