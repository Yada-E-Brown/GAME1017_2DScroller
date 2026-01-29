using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private SoundManager() { }

    private static SoundManager instance = null;
    public static SoundManager GetInstance()
    {
        if(instance == null)
        {
            instance = new SoundManager();
        }
        return instance;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
