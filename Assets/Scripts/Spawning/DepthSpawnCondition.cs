using UnityEngine;
using System.Collections;

public class DepthSpawnCondition : SpawnCondition
{
    public float startDepth;
    public float depthBase;
    public float depthVariation;
    public float nextSpawn;

    public override void Start()
    {
        base.Start();
        startDepth = background.distance;
        nextSpawn = startDepth + NextDepthDelta();
	}

    public override bool ShouldSpawn()
    {
        return background.distance > nextSpawn;
    }

    public override void OnSpawn(GameObject gameObject)
    {
        nextSpawn = nextSpawn + NextDepthDelta();
    }

    public float NextDepthDelta()
    {
        return depthBase + Random.Range(-depthVariation, depthVariation);
    }
}
