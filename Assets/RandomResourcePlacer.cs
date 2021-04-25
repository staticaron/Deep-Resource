using UnityEngine;
using System.Collections.Generic;

public class RandomResourcePlacer : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnPoints;

    [SerializeField]
    private int numberOfResourcesToBeSpawned;
    [SerializeField]
    private List<int> choosenIndices;

    [SerializeField]
    private GameObject resourceObject;

    private void Awake()
    {
        SpawnResources();
    }

    [ContextMenu("Spawn Resources")]
    public void SpawnResources()
    {
        int length = spawnPoints.Count;

        //Pick some random indices from the transform container
        while (choosenIndices.Count < numberOfResourcesToBeSpawned)
        {
            int pick = UnityEngine.Random.Range(0, length);
            if (choosenIndices.Contains(pick))
            {
                continue;
            }
            else
            {
                choosenIndices.Add(pick);
            }
        }

        //Spawn the resources
        foreach (int i in choosenIndices)
        {
            Instantiate(resourceObject, spawnPoints[i].position, Quaternion.identity, this.transform);
        }
    }
}
