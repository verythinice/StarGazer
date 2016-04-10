using UnityEngine;
using System.Collections;

public class EndlessLevel : Level
{
    public float[] spawnMin;
    public float[] spawnBase;
    public float[] spawnVariation;
    public GameObject[] spawnObject;
    
    public float maxIntensity;
    public float spawnY;

    public float intensity;
    public float[] nextSpawnDepth;

    public override void Start()
    {
        base.Start();
        nextSpawnDepth = new float[spawnMin.Length];
        for (int i = 0; i < spawnMin.Length; ++i)
        {
            nextSpawnDepth[i] = 5 + spawnMin[i] + ((spawnBase[i] + Random.Range(-spawnVariation[i], spawnVariation[i]) * (1.1f - intensity / maxIntensity)));
        }
    }

	public override void Update()
    {
        base.Update();
        intensity = background.distance;
        for (int i = 0; i < spawnMin.Length; ++i)
        {
            if (background.distance > nextSpawnDepth[i])
            {
                Spawn(spawnObject[i]);
                nextSpawnDepth[i] = background.distance + spawnMin[i] + ((spawnBase[i] + Random.Range(-spawnVariation[i], spawnVariation[i]) * (1.1f - intensity / maxIntensity)));
            }
        }
	}

    public void Spawn(GameObject type)
    {
        GameObject.Instantiate(type, new Vector3(Random.Range(minX, maxX), spawnY, 0), Quaternion.identity);
    }
}


/*

    public float solarFlareMin;
    public float solarFlareBase;
    public float solarFlareVariation;
    public GameObject solarFlare;

    public float asteroidMin;
    public float asteroidBase;
    public float aserteroidVariaton;
    public GameObject asteroidSpawner;

    public float towerMin;
    public float towerBase;
    public float towerVariation;
    public GameObject tower;

    public float healthMin;
    public float healthBase;
    public float healthVariation;
    public GameObject health;
*/