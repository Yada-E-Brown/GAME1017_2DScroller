using UnityEngine;
using System.Collections.Generic;

public class SegmentSpawner : MonoBehaviour
{
    public GameObject rooftopPrefab;
    public int numPlatformsPerChunk = 5;

    public float platformSpacing = 30f;
    public float spacingVariation = 5f;

    public float maxHeightVar = -3.0f;
    public float minHeightVar = -6.0f;

    public float widthVariation = 2f;
    float minWidth = 5; 
    float maxWidth = 15f;

    public GameObject playerCharacter;

    public List<GameObject> spawnedPlatforms = new List<GameObject>();
    

    void Start()
    {
        BuildSegmentsAt(new Vector3(10,0,0));
    }
    private void Update()
    {
        if (playerCharacter.transform.position.x > spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position.x)
        {
            BuildSegmentsAt(new Vector3((15 + spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position.x), 0, 0));
        }

        if (spawnedPlatforms.Count > numPlatformsPerChunk * 2)
        {
            Destroy(spawnedPlatforms[0]);
            spawnedPlatforms.RemoveAt(0);
        }
    }

    void BuildSegmentsAt(Vector3 posOffset)
    {
        float currentX = posOffset.x;

        for (int i = 0; i < numPlatformsPerChunk; i++)
        {
            float randomHeight = Random.Range(minHeightVar, maxHeightVar);

            // safer width range
            float randomWidth = Random.Range(minWidth, maxWidth);

            float randomSpacing = Random.Range(
                platformSpacing - spacingVariation,
                platformSpacing + spacingVariation
            );

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

            // Move X forward for the next platform
            currentX += randomSpacing;
        }
    }
}