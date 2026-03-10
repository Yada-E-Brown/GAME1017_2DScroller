using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SegmentSpawner : MonoBehaviour
{
    public GameObject rooftopPrefab;
    public int numPlatformsPerChunk = 5;

    public float platformSpacing = 12f;
    public float spacingVariation = 4f;

    public float heightVar = 6f;

    public float baseWidth = 10f;
    public float widthVariation = 0.2f;

    public List<GameObject> spawnedPlatforms = new List<GameObject>();

    void Start()
    {
        BuildSegmentsAt(Vector3.zero);
    }

    void BuildSegmentsAt(Vector3 posOffset)
    {
        float currentX = posOffset.x;

        for (int i = 0; i < numPlatformsPerChunk; i++)
        {
            float randomHeight = Random.Range(-heightVar, heightVar);
            float randomWidth = Random.Range( 1 - widthVariation, 1 + widthVariation);
            float randomSpacing = Random.Range(platformSpacing - spacingVariation, platformSpacing + spacingVariation);

            GameObject platform = Instantiate(
                rooftopPrefab,
                new Vector3(currentX, posOffset.y + randomHeight, 0),
                Quaternion.identity
            );

            Vector3 scale = platform.transform.localScale;
            platform.transform.localScale = new Vector3(randomWidth, scale.y, scale.z);

            spawnedPlatforms.Add(platform);

            currentX += randomSpacing;
        }
    }
}