using UnityEngine;
using System.Collections;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject[] Builds;
    public float spawnDistanceBuildPosition = 50f; // distance at which new buildings are spawned
    public float spawnFrequency = 2f; // how often new buildings are spawned
    public float destroyDistance = 100f; // distance behind the player at which buildings are destroyed
    private float lastSpawnTime; // time when the last building was spawned
    [HideInInspector]
    public Transform player; // reference to the player's transform
    private int randomBuild;
    public Transform MainPlane;
    [Header("Distance from the player")]
    public float Distance_FP;
    public GameObject[] buildings;
    void Awake()
    {
        lastSpawnTime = Time.time;
    }
    //Test=>Can be problem
    void Update()
    {
        // check if the player has moved far enough to spawn a new building
        if (player!=null)
        if (Vector3.Distance(player.position, transform.position) > Distance_FP)
        {
            // check if enough time has passed since the last building was spawned
           if (Time.time - lastSpawnTime > spawnFrequency)
           {
                SpawnBuild();
           }
        }
        // check if any buildings are behind the player and far enough to be destroyed
        buildings = GameObject.FindGameObjectsWithTag("Building");
        if (player!=null)
        foreach (GameObject building in buildings)
        {
            if (building.transform.position.z > player.position.z + destroyDistance)
            {
                Destroy(building);
            }
        }
        if (player != null)
            MainPlane.localPosition= new Vector3(MainPlane.localPosition.x, MainPlane.localPosition.y,player.localPosition.z-1000);
    }
    public void SpawnBuild()
    {
        // spawn a new building
        randomBuild = Random.Range(0, Builds.Length);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, player.transform.localPosition.z);
        Vector3 spawnPosition = new Vector3(transform.position.x, buildings[buildings.Length - 1].transform.position.y, buildings[buildings.Length-1].transform.position.z - spawnDistanceBuildPosition);
        Instantiate(Builds[randomBuild], spawnPosition, Builds[randomBuild].transform.rotation);
        lastSpawnTime = Time.time;
    }
}