using UnityEngine;
using System.Collections;

public class DriftSpawner : Spawner
{
    public float driftSpeedBase;
    public float driftSpeedVariation;
    public Vector2 driftDirection;

    public override void Spawn()
    {
        GameObject spawnedObject = (GameObject)GameObject.Instantiate(spawnPrefab, transform.position, transform.rotation);
        Vector2 direction = driftDirection;
        if (driftDirection.x == 0 && driftDirection.y == 0)
        {
            direction.x = Random.Range(-1.0f, 1.0f);
            direction.y = Random.Range(-1.0f, 1.0f);
            direction.Normalize();
        }

        Drift drift = spawnedObject.AddComponent<Drift>();
        drift.direction = direction;
        drift.speed = driftSpeedBase + Random.Range(-driftSpeedVariation, driftSpeedVariation);
        
        condition.OnSpawn(spawnedObject);
    }
}
