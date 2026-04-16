using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SegmentSpawner : MonoBehaviour
{
    [SerializeField]
    public TMP_Text DifficultyText;
    public GameObject rooftopPrefab;
    public int numPlatformsPerChunk = 5;

    float minSpacing = 15f;
    float maxSpacing = 20f;

    public float maxHeightVar = -3.0f;
    public float minHeightVar = -6.0f;

    public float widthVariation = 2f;
    float minWidth = 5;
    float maxWidth = 15f;

    public GameObject playerCharacter;

    public List<GameObject> spawnedPlatforms = new List<GameObject>();

    private bool hasInitialized = false;

    private float difficultyTimer = 0f;
    public float difficultyInterval = 10f;

    public float spacingIncrease = 2f;
    public float speedIncrease = 0.2f;

    //Speed cap
    public float maxSpacingCap = 40f;
    public float maxSpeedMultiplier = 3f;

    public float difficultyLevel = 0f;


    void Start()
    {
        FindPlayer();
        spawnedPlatforms.Clear();
        BuildSegmentsAt(new Vector3(10, 0, 0));
        hasInitialized = true;
    }
    private void FindPlayer()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        DifficultyText.text = "Level: " + difficultyLevel;
        if (GameManager.Instance.CurrentState != GameManager.States.Play)
            return;


        if (playerCharacter == null)
        {
            FindPlayer();
            return;
        }
        spawnedPlatforms.RemoveAll(platform => platform == null);
        if (spawnedPlatforms.Count > 0 && hasInitialized)
        {
            GameObject lastPlatform = spawnedPlatforms[spawnedPlatforms.Count - 1];
            if (lastPlatform != null &&
                playerCharacter.transform.position.x > lastPlatform.transform.position.x - 10f)
            {
                BuildSegmentsAt(new Vector3(
                    lastPlatform.transform.position.x + Random.Range(minSpacing, maxSpacing),0,0));
            }
        }
        while (spawnedPlatforms.Count > numPlatformsPerChunk * 2)
        {
            if (spawnedPlatforms[0] != null)
            {
                Destroy(spawnedPlatforms[0]);
            }
            spawnedPlatforms.RemoveAt(0);
        }
        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0f;
            difficultyLevel++;


            // Increase platform spacing
            minSpacing += spacingIncrease;
            maxSpacing += spacingIncrease;

            minSpacing = Mathf.Min(minSpacing, maxSpacingCap);
            maxSpacing = Mathf.Min(maxSpacing, maxSpacingCap);

            // Increase player speed
            PlayerMovement playerMove = playerCharacter.GetComponent<PlayerMovement>();
            if (playerMove != null)
            {
                playerMove.IncreaseSpeed(speedIncrease, maxSpeedMultiplier);
            }
        }
    }
    void BuildSegmentsAt(Vector3 posOffset)
    {
        float currentX = posOffset.x;

        for (int i = 0; i < numPlatformsPerChunk; i++)
        {
            float randomHeight = Random.Range(minHeightVar, maxHeightVar);
            float randomWidth = Random.Range(minWidth, maxWidth);
            float randomSpacing = Random.Range(minSpacing, maxSpacing);

            GameObject platform = Instantiate(
                rooftopPrefab,
                new Vector3(currentX, randomHeight, 0),
                Quaternion.identity
            );

            Vector3 scale = platform.transform.localScale;
            platform.transform.localScale = new Vector3(
                randomWidth,
                scale.y,
                scale.z
            );
            spawnedPlatforms.Add(platform);
            currentX += randomSpacing;
        }
    }
    public void ResetSpawner()
    {
        foreach (var platform in spawnedPlatforms)
        {
            if (platform !=null)
                Destroy(platform);
        }
        spawnedPlatforms.Clear();
        FindPlayer();
    }
}