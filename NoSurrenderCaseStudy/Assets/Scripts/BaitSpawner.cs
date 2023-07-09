using UnityEngine;

public class BaitSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 4f;
    public float spawnRadius = 10f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    private void SpawnCube()
    {
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;       
        Instantiate(cubePrefab, randomPosition, Quaternion.identity);
    }
}                                 //10 birim uzakl��a kadar yem spawnlacak ve bu 2 saniyede 1 olacak ve odaklan�lan cubePrefab s�rekli bu kriterler aras�nda spawnlanacak.