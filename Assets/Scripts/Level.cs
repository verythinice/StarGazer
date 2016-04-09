using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    public float gameTime;
    public GameObject[] spawn;
    public float[] yPos;
    public float[] spawnTime;
    public int nextSpawn;

	// Use this for initialization
	void Start()
    {
        gameTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update()
    {
        gameTime += Time.deltaTime;
        if (nextSpawn < spawnTime.Length && gameTime >= spawnTime[nextSpawn])
        {
            nextSpawn++;
        }
	}
}
