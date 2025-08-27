using UnityEngine;

public class EnergySpawner : MonoBehaviour
{
    public GameObject energyPrefab; // Reference to the energy prefab
    public Transform[] SpawnPoints; // Array of spawn points
    public float spawnInterval;
    public float Timer;


    void Start()
    {
        SetRandomTimeInterval();
    }
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            SpawnEnergy();
            SetRandomTimeInterval();
        }
    }


    void SpawnEnergy()
    {
        if(SpawnPoints.Length == 0 || energyPrefab == null)
        {
            Debug.LogWarning("Spawn points or energy prefab not set.");
            return;
        }

        int randomIndex = Random.Range(0, SpawnPoints.Length);
        Transform SpawnPoint = SpawnPoints[randomIndex];
        Instantiate(energyPrefab, SpawnPoint.position, Quaternion.identity);

    }
    private void SetRandomTimeInterval()
    {
               spawnInterval = Random.Range(10f, 15f); 
                Timer = spawnInterval; 
    }
}
