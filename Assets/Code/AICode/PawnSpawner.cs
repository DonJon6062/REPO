using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSpawner : MonoBehaviour
{
    public GameObject AIControllerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAI(PawnSpawner spawnPoint)
    { 
        GameObject newAiObject = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
    }
}
