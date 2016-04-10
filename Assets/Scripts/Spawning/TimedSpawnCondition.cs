using UnityEngine;
using System.Collections;

public class TimedSpawnCondition : SpawnCondition 
{
    public float spawnTimeBase;
    public float spawnTimeVariation;
    public float spawnReady;

	public override void Start()
    {
        base.Start();
        spawnReady = GetNewSpawnTime();
	}
	
    float GetNewSpawnTime()
    {
        return spawnTimeBase + Random.Range(-spawnTimeVariation, spawnTimeVariation);
    }

    public override void Update()
    {
        base.Update();
        spawnReady -= Time.deltaTime;
    }

	public override bool ShouldSpawn()
    {
        return spawnReady <= 0.0f;
    }

    public override void OnSpawn(GameObject spawnedObject)
    {
        spawnReady = GetNewSpawnTime();
    }
}
