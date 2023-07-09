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
}                                 //10 birim uzaklýða kadar yem spawnlacak ve bu 2 saniyede 1 olacak ve odaklanýlan cubePrefab sürekli bu kriterler arasýnda spawnlanacak.