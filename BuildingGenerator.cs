using UnityEngine;
using System.Collections;

public class BuildingGenerator : MonoBehaviour
{
    private GameObject buildingPrefab; // assign a building prefab in the inspector
    public GameObject[] Builds;
    public float spawnDistance = 50f; // distance at which new buildings are spawned
    public float spawnFrequency = 2f; // how often new buildings are spawned
    public float destroyDistance = 100f; // distance behind the player at which buildings are destroyed
    private float lastSpawnTime; // time when the last building was spawned
    private Transform player; // reference to the player's transform
    public float random;
    public int randomBuild;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        // check if the player has moved far enough to spawn a new building
        if (Vector3.Distance(player.position, transform.position) > spawnDistance)
        {
            // check if enough time has passed since the last building was spawned
            if (Time.time - lastSpawnTime > spawnFrequency)
            {
                // spawn a new building
                randomBuild = Random.Range(0, 3);
                buildingPrefab = Builds[randomBuild];
                spawnDistance -= 10;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, player.transform.localPosition.z + spawnDistance);
                Vector3 spawnPosition = new Vector3(transform.position.x+random, transform.position.y , transform.position.z + spawnDistance);
                Instantiate(buildingPrefab, spawnPosition, buildingPrefab.transform.rotation);
                lastSpawnTime = Time.time;
                random = Random.Range(-10.0f, 25.0f);
            }
        }
        // check if any buildings are behind the player and far enough to be destroyed
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        foreach (GameObject building in buildings)
        {
            if (building.transform.position.z > player.position.z+ destroyDistance)
            {
                Destroy(building);
            }
        }
    }
}